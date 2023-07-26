using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy4 : Enemy
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private float power;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Update()
    {
        base.Update();
        Attack();
    }

    private void Attack()
    {
        Collider[] collider = Physics.OverlapSphere(this.transform.position, radius);
        foreach (Collider col in collider)
        {
            if (col.gameObject.name == "Npc")
                col.gameObject.GetComponent<NPC>().Patience -= power;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }
}