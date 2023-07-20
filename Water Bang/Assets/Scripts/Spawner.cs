using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner: MonoBehaviour
{
    public float respawnDelay;
    public float spawnDuration;

    private void SpawnCharacter()
    {
        var character = ObjectPool.GetObject();
        character.SetDuration(spawnDuration);
    }

    void Start()
    {
        InvokeRepeating("SpawnCharacter", 5, respawnDelay);
    }

    void Update()
    {

    }
}
