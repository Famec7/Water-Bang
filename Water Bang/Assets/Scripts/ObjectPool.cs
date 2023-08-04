using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField]
    private GameObject npc1Prefab;
    [SerializeField]
    private GameObject npc2Prefab;
    private List<GameObject> npcPool;
    public int npcCount;

    [SerializeField]
    private GameObject enemy1Prefab;
    [SerializeField]
    private GameObject enemy2Prefab;
    [SerializeField]
    private GameObject enemy3Prefab;
    private List<GameObject> enemyPool;
    public int enemyCount;

    [SerializeField]
    private GameObject specialEnemy1Prefab;
    private List<GameObject> specialEnemy1Pool;
    public int specialEnemy1Count;

    [SerializeField]
    private GameObject specialEnemy2Prefab;
    private List<GameObject> specialEnemy2Pool;
    public int specialEnemy2Count;

    [SerializeField]
    private GameObject specialEnemy3Prefab;
    private List<GameObject> specialEnemy3Pool;
    public int specialEnemy3Count;

    [SerializeField]
    private GameObject specialEnemy4Prefab;
    private List<GameObject> specialEnemy4Pool;
    public int specialEnemy4Count;

    [SerializeField]
    private GameObject whistlePrefab;
    [SerializeField]
    private GameObject waterBombPrefab;
    [SerializeField]
    private GameObject energyDrinkPrefab;
    private List<GameObject> ItemPool;
    public int ItemCount;

    [SerializeField]
    private GameObject waterPrefab;
    private List<GameObject> waterDrops;
    public int waterDropCount;

    private List<GameObject> pool;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(instance);
        InitialiizePool();
    }

    private void InitialiizePool()
    {
        npcPool = new List<GameObject>();
        enemyPool = new List<GameObject>();
        specialEnemy1Pool = new List<GameObject>();
        specialEnemy2Pool = new List<GameObject>();
        specialEnemy3Pool = new List<GameObject>();
        specialEnemy4Pool = new List<GameObject>();
        ItemPool = new List<GameObject>();
        waterDrops = new List<GameObject>();
        for (int i = 0; i < npcCount; i++)
        {
            GameObject newObj = CreateObject("npc");
            npcPool.Add(newObj);
        }
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newObj = CreateObject("enemy");
            enemyPool.Add(newObj);
        }
        for (int i = 0; i < specialEnemy1Count; i++)
        {
            GameObject newObj = CreateObject("specialEnemy1");
            specialEnemy1Pool.Add(newObj);
        }
        for (int i = 0; i < specialEnemy2Count; i++)
        {
            GameObject newObj = CreateObject("specialEnemy2");
            specialEnemy2Pool.Add(newObj);
        }
        for (int i = 0; i < specialEnemy3Count; i++)
        {
            GameObject newObj = CreateObject("specialEnemy3");
            specialEnemy3Pool.Add(newObj);
        }
        for (int i = 0; i < specialEnemy4Count; i++)
        {
            GameObject newObj = CreateObject("specialEnemy4");
            specialEnemy4Pool.Add(newObj);
        }
        for(int i = 0; i < ItemCount; i++)
        {
            GameObject newObj = CreateObject("item");
            ItemPool.Add(newObj);
        }
        for(int i = 0; i < waterDropCount; i++)
        {
            GameObject newObj = CreateObject("waterDrop");
            waterDrops.Add(newObj);
        }
    }

    private GameObject CreateObject(string type)
    {
        GameObject newObj = null;
        switch (type)
        {
            case "npc":
                int num = Random.Range(1, 3);
                if (num == 1)
                    newObj = Instantiate(npc1Prefab);
                else if (num == 2)
                    newObj = Instantiate(npc2Prefab);
                newObj.SetActive(false);
                break;
            case "enemy":
                num = Random.Range(1, 4);
                if(num == 1)
                    newObj = Instantiate(enemy1Prefab);
                else if(num == 2)
                    newObj = Instantiate(enemy2Prefab);
                else if(num == 3)
                    newObj = Instantiate(enemy3Prefab);
                newObj.SetActive(false);
                break;
            case "specialEnemy1":
                newObj = Instantiate(specialEnemy1Prefab);
                newObj.SetActive(false);
                break;
            case "specialEnemy2":
                newObj = Instantiate(specialEnemy2Prefab);
                newObj.SetActive(false);
                break;
            case "specialEnemy3":
                newObj = Instantiate(specialEnemy3Prefab);
                newObj.SetActive(false);
                break;
            case "specialEnemy4":
                newObj = Instantiate(specialEnemy4Prefab);
                newObj.SetActive(false);
                break;
            case "item":
                int rand = Random.Range(0, 3);
                if (rand == 0)
                    newObj = Instantiate(whistlePrefab);
                else if (rand == 1)
                    newObj = Instantiate(waterBombPrefab);
                else if (rand == 2)
                    newObj = Instantiate(energyDrinkPrefab);
                newObj.SetActive(false);
                break;
            case "waterDrop":
                newObj = Instantiate(waterPrefab);
                newObj.SetActive(false);
                break;
            default: break;
        }

        return newObj;
    }

    // GetObject 호출 시 활성화된 오브젝트를 리턴(따로 활성화할 필요X)
    public GameObject GetObject(string type)
    {
        switch(type)
        {
            case "npc":
                pool = npcPool;
                break;
            case "enemy":
                pool = enemyPool;
                break;
            case "specialEnemy1":
                pool = specialEnemy1Pool;
                break;
            case "specialEnemy2":
                pool = specialEnemy2Pool;
                break;
            case "specialEnemy3":
                pool = specialEnemy3Pool;
                break;
            case "specialEnemy4":
                pool = specialEnemy4Pool;
                break;
            case "item":
                pool = ItemPool;
                break;
            case "waterDrop":
                pool = waterDrops;
                break;
            default: break;
        }

        foreach (GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    }

    // 활성화된 오브젝트를 비활성화
    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void Reset()
    {
        foreach (GameObject obj in npcPool)
            if(obj.activeSelf)
                obj.SetActive(false);
        foreach (GameObject obj in enemyPool)
            if (obj.activeSelf)
                obj.SetActive(false);
        foreach (GameObject obj in specialEnemy1Pool)
            if (obj.activeSelf)
                obj.SetActive(false);
        foreach (GameObject obj in specialEnemy2Pool)
            if (obj.activeSelf)
                obj.SetActive(false);
        foreach (GameObject obj in specialEnemy3Pool)
            if (obj.activeSelf)
                obj.SetActive(false);
        foreach (GameObject obj in specialEnemy4Pool)
            if (obj.activeSelf)
                obj.SetActive(false);
    }
}
