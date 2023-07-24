using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private GameObject transformPrefab;

    public float scale;
    public float speed;
    private float fixedDelay = 0.1f;
    private float minX = -9.6f, maxX = 9.6f;
    private float minY = -5.4f, maxY = 5.4f;

    private GameObject movePosition;
    private float moveDelay;

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
        moveDelay = fixedDelay;
        transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        CreateNewTransform();
        movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GetComponent<SpriteRenderer>().flipX = IsFlip();
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
                GetComponent<SpriteRenderer>().flipX = IsFlip();
                moveDelay = fixedDelay;
            }
            else
            {
                moveDelay -= Time.deltaTime;
            }
        }
    }
}