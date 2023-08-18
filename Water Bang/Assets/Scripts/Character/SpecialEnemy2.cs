using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy2 : Character
{
    private float responeTime;
    [SerializeField] private float spawnNumber;
    [SerializeField] private float radius;

    public AudioClip attackClip;

    protected override void Awake()
    {
        base.Awake();
        responeTime = Random.Range(3, 9);
    }
    private void Start()
    {
        StartCoroutine("Spawn");
    }
    protected override void Update()
    {
        base.Update();
    }
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(responeTime);
            sfx.PlayOneShot(attackClip);
            for (int i = 0; i < spawnNumber; i++)
            {
                GameObject enemy = ObjectPool.instance.GetObject("enemy");
                // 적 스폰 방식은 주어진 반지름 안에서 랜덤으로 생성
                enemy.gameObject.transform.position = GetPosition();
                GameManager.instance.AllCount++;
            }
        }
    }

    private Vector3 GetPosition()
    {
        float a = this.transform.position.x;
        float b = this.transform.position.y;

        // (x - a)^2 + (y - b)^2 = radius^2
        // x값을 랜덤으로 뽑은 후 위 방정식을 이용해 y값 구하기
        float x = Random.Range(a - radius, a + radius);
        float y = Mathf.Sqrt(radius * radius - Mathf.Pow(x - a, 2)) + b;

        Vector3 enemyPosition = new Vector3(x, y, 0);

        return enemyPosition;
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
