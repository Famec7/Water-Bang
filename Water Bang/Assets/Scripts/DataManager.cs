using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public bool Stage2;
    public bool Stage3;
}

public class DataManager : MonoBehaviour
{
    string path;
    public static DataManager instance;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        path = Path.Combine(Application.dataPath, "savedata.json");
        DataLoad();
    }

    public void DataLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            GameManager.instance.lockStage2 = true;
            GameManager.instance.lockStage3 = true;
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                GameManager.instance.lockStage2 = saveData.Stage2;
                GameManager.instance.lockStage3 = saveData.Stage3;
            }
        }
    }

    public void DataSave()
    {
        SaveData saveData = new SaveData();
        saveData.Stage2 = GameManager.instance.lockStage2;
        saveData.Stage3 = GameManager.instance.lockStage3;

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(path, json);
        Debug.Log(json);
    }
}
