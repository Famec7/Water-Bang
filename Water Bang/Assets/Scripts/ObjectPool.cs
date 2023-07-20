using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;
    public int initCount;

    Queue<Character> poolingObjectQueue = new Queue<Character>();

    private void Awake()
    {
        Instance = this;
        InitializeQueue(initCount);
    }

    private void InitializeQueue(int initCount)
    {
        for (int i = 0; i < initCount; i++) poolingObjectQueue.Enqueue(CreateNewObject());
    }

    private Character CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Character>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform, false);
        return newObj;
    }

    public static Character GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(Character obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform, false);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
