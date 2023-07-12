using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField]
    private GameObject transformPrefab;

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
    }

    void Start()
    {
        Invoke("DestroyCharacter", Duration);
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePosition.transform.position, Speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePosition.transform.position) < 0.3)
        {
            if (moveDelay <= 0)
            {
                movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                moveDelay = fixedDelay;
            }
            else
            {
                moveDelay -= Time.deltaTime;
            }
        }
    }
}
