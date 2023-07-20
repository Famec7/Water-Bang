using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy2 : Character
{
    private float time = 0f;
    [SerializeField] private float responeTime;
    [SerializeField] private float spawnNumber;
    [SerializeField] private float radius;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
        time += Time.deltaTime;
        Spawn();
    }
    private void Spawn()
    {
        if (time > responeTime)
        {
            for (int i = 0; i < spawnNumber; i++)
            {
                GameObject enemy = ObjectPool.instance.GetObject("enemy");
                // �� ���� ����� �־��� ������ �ȿ��� �������� ����
                enemy.gameObject.transform.position = GetPosition();
            }
            time = 0f;
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
}
