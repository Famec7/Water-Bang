using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private GameObject transformPrefab;

    public float Scale;
    public float Speed;
    public float fixedDelay;
    public float minX, maxX;
    public float minY, maxY;

    private GameObject movePosition;
    private float moveDelay;
    private float Duration;

    public void SetDuration(float activeDuration)
    {
        Duration = activeDuration;
    }

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
        transform.localScale = new Vector3((1 + magScale) * Scale, (1 + magScale) * Scale);
    }

    public void DestroyCharacter()
    {
        ObjectPool.ReturnObject(this);
    }

    private void OnMouseDown()
    {
        DestroyCharacter();
    }

    void Awake()
    {
        moveDelay = fixedDelay;
        transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        CreateNewTransform();
        movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        GetComponent<SpriteRenderer>().flipX = IsFlip();
    }

    void Start()
    {
        Invoke("DestroyCharacter", Duration);
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePosition.transform.position, Speed * Time.deltaTime);
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