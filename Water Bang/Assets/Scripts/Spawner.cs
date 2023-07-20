using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    public float respawnDelay;
    public float spawnDuration;
    private bool isSpawn = false;

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(respawnDelay);
        GameObject obj = ObjectPool.instance.GetObject("enemy");
        Debug.Log("Spawn");

        isSpawn = false;
    }

    private void Update()
    {
        if(!isSpawn)
        {
            isSpawn = true;
            StartCoroutine("SpawnEnemy");
        }
    }
}
