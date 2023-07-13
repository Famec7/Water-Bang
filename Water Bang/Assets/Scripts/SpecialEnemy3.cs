using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy3 : Character
{
    [SerializeField] private float attackTime;
    [SerializeField] private float duration;
    private GameObject water;
    private float time = 0f;

    private void Awake()
    {
        water = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
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
        if(time > duration && water.activeSelf)
        {
            water.SetActive(false);
            time = 0f;
        }
    }
}
