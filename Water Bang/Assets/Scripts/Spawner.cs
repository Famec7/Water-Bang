using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float respawnDelay;

    public float npcRespawnDelay;
    public float enemyRespawnDelay;
    public float specialEnemy1RespawnDelay;
    public float specialEnemy2RespawnDelay;
    public float specialEnemy3RespawnDelay;
    public float specialEnemy4RespawnDelay;

    private int npcCount = GameManager.instance.npcCount;
    private int enemyCount = GameManager.instance.enemyCount;
    private int specialEnemy1Count = GameManager.instance.specialEnemy1Count;
    private int specialEnemy2Count = GameManager.instance.specialEnemy2Count;
    private int specialEnemy3Count = GameManager.instance.specialEnemy3Count;
    private int specialEnemy4Count = GameManager.instance.specialEnemy4Count;

    private IEnumerator SpawnEnemy(string type)
    {
        while (true)
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
    }

    private void Start()
    {
        /*StartCoroutine(SpawnEnemy("npc"));
        StartCoroutine(SpawnEnemy("enemy"));
        StartCoroutine(SpawnEnemy("specialEnemy1"));
        StartCoroutine(SpawnEnemy("specialEnemy2"));
        StartCoroutine(SpawnEnemy("specialEnemy3"));
        StartCoroutine(SpawnEnemy("specialEnemy4"));*/

        Spawn("npc", npcCount);
        Spawn("enemy", enemyCount);
        Spawn("specialEnemy1", specialEnemy1Count);
        Spawn("specialEnemy2", specialEnemy2Count);
        Spawn("specialEnemy3", specialEnemy3Count);
        Spawn("specialEnemy4", specialEnemy4Count);
    }

    private void Spawn(string type, int count)
    {
        GameObject obj = null;
        for (int i = 0; i < count; i++)
            obj = ObjectPool.instance.GetObject(type);
    }
}
