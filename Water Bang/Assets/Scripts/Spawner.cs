using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float npcRespawnDelay;
    public float enemyRespawnDelay;
    public float specialEnemy1RespawnDelay;
    public float specialEnemy2RespawnDelay;
    public float specialEnemy3RespawnDelay;
    public float specialEnemy4RespawnDelay;

    private float respawnDelay;

    private IEnumerator SpawnEnemy(string type)
    {
        switch (type)
        {
            case "npc":
                respawnDelay = npcRespawnDelay; break;
            case "enemy":
                respawnDelay = enemyRespawnDelay; break;
            case "specialEnemy1":
                respawnDelay = specialEnemy1RespawnDelay; break;
            case "specialEnemy2":
                respawnDelay = specialEnemy2RespawnDelay; break;
            case "specialEnemy3":
                respawnDelay = specialEnemy3RespawnDelay; break;
            case "specialEnemy4":
                respawnDelay = specialEnemy4RespawnDelay; break;
            default:
                break;
        }

        yield return new WaitForSeconds(respawnDelay);
        GameObject obj = ObjectPool.instance.GetObject(type);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy("npc"));
        StartCoroutine(SpawnEnemy("enemy"));
        StartCoroutine(SpawnEnemy("specialEnemy1"));
        StartCoroutine(SpawnEnemy("specialEnemy2"));
        StartCoroutine(SpawnEnemy("specialEnemy3"));
        StartCoroutine(SpawnEnemy("specialEnemy4"));
    }
}
