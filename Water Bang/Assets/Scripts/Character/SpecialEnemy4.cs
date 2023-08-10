using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy4 : Character
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private float power;
    [SerializeField]
    private float attackTime;

    private AudioSource sfx;
    protected override void Awake()
    {
        base.Awake();
        sfx = GetComponent<AudioSource>();
    }
    private void Start()
    {
        StartCoroutine("Attack");
    }
    protected override void Update()
    {
        base.Update();
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            sfx.PlayOneShot(sfx.clip);
            Collider2D[] collider = Physics2D.OverlapCircleAll(this.transform.position, radius);
            foreach (Collider2D col in collider)
            {
                if (col.gameObject.CompareTag("Npc"))
                    ScoreManager.instance.Score -= power;   // ���ӸŴ����� �ִ� ������ �����ϴ� ������� �����ϱ�
            }

            yield return new WaitForSeconds(attackTime);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
