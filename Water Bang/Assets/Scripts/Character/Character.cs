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
    private Animator animator;

    protected AudioSource sfx;
    public AudioClip hitClip;

    public States currentState = States.Idle;

    private void CreateNewTransform()
    {
        movePosition = Instantiate(transformPrefab);
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

    protected virtual void Awake()
    {
        sfx = GetComponent<AudioSource>();
        Vector3 minPos = Camera.main.ViewportToWorldPoint(new Vector3(minX, minY, 0));
        Vector3 maxPos = Camera.main.ViewportToWorldPoint(new Vector3(maxX, maxY, 0));

        minX = minPos.x; minY = minPos.y;
        maxX = maxPos.x; maxY = maxPos.y;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveDelay = fixedDelay;
        transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY / 3, maxY / 3));
        CreateNewTransform();
        movePosition.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        spriteRenderer.flipX = IsFlip();
    }

    protected virtual void Update()
    {
        if (GameManager.instance.currentState == GameStates.inGame)
        {
            switch (currentState)
            {
                case States.Idle:
                    animator.SetBool("Idle", true);
                    animator.SetBool("Exit", false);
                    break;
                case States.Exit:
                    StartCoroutine("Exit");
                    break;
                default:
                    break;
            }
            RandomMove();
        }
    }

    private IEnumerator Exit()
    {
        float tmp = speed;
        speed = 0;
        if(!sfx.isPlaying)
            sfx.PlayOneShot(hitClip);
        animator.SetBool("Idle", false);
        animator.SetBool("Exit", true);

        yield return new WaitForSecondsRealtime(0.5f);    // 퇴장 애니메이션 시간으로 설정하기
        ObjectPool.instance.ReturnObject(this.gameObject);
        if (gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.AllCount--;
            DropItem();
        }
        currentState = States.Idle;
        speed = tmp;
    }

    private void DropItem()
    {
        int random = Random.Range(0, 10);

        if (random == 0 || random == 1 || random == 2)
        {
            GameObject item = ObjectPool.instance.GetObject("item");
            if (item != null)
                item.transform.position = this.gameObject.transform.position;
        }
    }

    private void RandomMove()
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

    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("TopStage"))
        {
            movePosition.transform.position = new Vector2(Random.Range(minX, maxX), 0);
        }
        else if (collider.CompareTag("BottomStage"))
        {
            movePosition.transform.position = new Vector2(Random.Range(minX, maxX), 0);
        }
    }
}