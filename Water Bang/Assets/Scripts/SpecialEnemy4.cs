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
    protected override void Awake()
    {
        base.Awake();
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
            Collider2D[] collider = Physics2D.OverlapCircleAll(this.transform.position, radius);
            foreach (Collider2D col in collider)
            {
                if (col.gameObject.CompareTag("Npc"))
                    col.gameObject.GetComponent<NPC>().Patience -= power;   // 게임매니저에 있는 점수를 감점하는 방식으로 변경하기
            }

            yield return new WaitForSeconds(attackTime);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        base.OnTriggerEnter2D(collider);
    }
}
