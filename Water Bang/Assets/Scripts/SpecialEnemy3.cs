using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy3 : Character
{
    [SerializeField] private float attackTime;
    [SerializeField] private float attackDuration;
    private GameObject water;
    private float time = 0f;

    protected override void Awake()
    {
        base.Awake();
        water = transform.GetChild(0).gameObject;
    }
    protected override void Update()
    {
        base .Update();
        time += Time.deltaTime;
        Attack();
    }

    public void Attack()
    {
        if(time > attackTime && !water.activeSelf)
        {
            water.SetActive(true);
            time = 0f;
        }
        if(time > attackDuration && water.activeSelf)
        {
            water.SetActive(false);
            time = 0f;
        }
    }
}
