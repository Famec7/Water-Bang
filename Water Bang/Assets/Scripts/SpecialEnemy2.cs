using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy2 : Character
{
    [SerializeField] private float responeTime;
    [SerializeField] private float spawnNumber;
    [SerializeField] private float radius;

    protected override void Awake()
    {
        base.Awake();
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
            for (int i = 0; i < spawnNumber; i++)
            {
                GameObject enemy = ObjectPool.instance.GetObject("enemy");
                // �� ���� ����� �־��� ������ �ȿ��� �������� ����
                enemy.gameObject.transform.position = GetPosition();
                Debug.Log("Spawn");
            }
        }
    }

    private Vector3 GetPosition()
    {
        float a = this.transform.position.x;
        float b = this.transform.position.y;

        // (x - a)^2 + (y - b)^2 = radius^2
        // x���� �������� ���� �� �� �������� �̿��� y�� ���ϱ�
        float x = Random.Range(a - radius, a + radius);
        float y = Mathf.Sqrt(radius * radius - Mathf.Pow(x - a, 2)) + b;

        Vector3 enemyPosition = new Vector3(x, y, 0);

        return enemyPosition;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}
