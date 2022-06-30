using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private static string DataPath;
    public PlayerData playerData
    {
        get;
        private set;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Init();
    }

    private void Init()
    {
        DataPath = Application.persistentDataPath;
        LoadData();
    }

    public void SaveData()
    {
        if(playerData != null)
        {
            string data = JsonUtility.ToJson(playerData);
            File.WriteAllText($"{DataPath}/PlayerData.dat", data);
        }
    }

    public List<string> GetListTextPlayerContent()
    {
        return playerData.lstTextPlayerContent;
    }

    private void LoadData()
    {
        if(File.Exists($"{DataPath}/PlayerData.dat"))
        {
            playerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText($"{DataPath}/PlayerData.dat"));
        }
        else
        {
            playerData = new PlayerData();
            SaveData();
        }
    }
}
