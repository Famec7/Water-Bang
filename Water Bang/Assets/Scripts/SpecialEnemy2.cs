using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEnemy2 : MonoBehaviour, ISpawn
{
    [SerializeField] private GameObject enemy;
    private float time = 0f;
    [SerializeField] private float responeTime;
    [SerializeField] private float spawnNumber;
    [SerializeField] private float duration;

    private void Update()
    {
        time += Time.deltaTime;
        Spawn();
    }
    public void Spawn()
    {
        if (time > responeTime)
        {
            for (int i = 0; i < spawnNumber; i++)
            {
                Character enemy = ObjectPool.GetObject();
                enemy.SetDuration(duration);
            }
            time = 0f;
        }
    }
}
