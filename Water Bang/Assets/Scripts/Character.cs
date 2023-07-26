using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum States
{
    Idle,
    Exit
}
public class Character : MonoBehaviour
{
    [SerializeField]
    private GameObject transformPrefab;

    public float scale;
    public float speed;
    private float fixedDelay = 0.1f;
    private float minX = 0f, maxX = 1f;
    private float minY = 0f, maxY = 1f;
    private SpriteRenderer spriteRenderer;

    private GameObject movePosition;
    private float moveDelay;

    public States currentState = States.Idle;

    private void CreateNewTransform()
    {
        movePosition = Instantiate(transformPrefab);
        /*GameObject temp = Instantiate(transformPrefab);
        temp.transform.SetParent(this.transformPrefab.transform, false);
        movePosition = temp;*/
    }

    private bool IsFlip()
    {
        float isFlip = transform.position.x - movePosition.transform.position.x;
        if (isFlip > 0) return false;
        else return true;
    }

    private void SetScale()
    {
        float rangeY = maxY - minY, centerY = (maxY + minY) / 2;
        float magScale = (centerY - transform.position.y) / rangeY;
        transform.localScale = new Vector3((1 + magScale) * scale, (1 + magScale) * scale);
    }

    public void DestroyCharacter()
    {
        ObjectPool.instance.ReturnObject(this.gameObject);
    }

    private void OnMouseDown()
    {
        DestroyCharacter();
    }

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveDelay = fixedDelay;
        transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        CreateNewTransform();
        movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        spriteRenderer.flipX = IsFlip();

        Vector3 minPos = Camera.main.ViewportToWorldPoint(new Vector3(minX, minY, 0));
        Vector3 maxPos = Camera.main.ViewportToWorldPoint(new Vector3(maxX, maxY, 0));

        minX = minPos.x; minY = minPos.y;
        maxX = maxPos.x; maxY = maxPos.y;
    }

    protected virtual void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePosition.transform.position, speed * Time.deltaTime);
        SetScale();
        if (Vector2.Distance(transform.position, movePosition.transform.position) < 0.3)
        {
            if (moveDelay <= 0)
            {
                movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                spriteRenderer.flipX = IsFlip();
                moveDelay = fixedDelay;
            }
            else
            {
                moveDelay -= Time.deltaTime;
            }
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TopStage"))
        {
            movePosition.transform.position = Vector3.zero;
            moveDelay = fixedDelay;
        }
        else if (collision.collider.CompareTag("BottomStage"))
        {
            movePosition.transform.position = Vector3.zero;
            moveDelay = fixedDelay;
        }
    }
}