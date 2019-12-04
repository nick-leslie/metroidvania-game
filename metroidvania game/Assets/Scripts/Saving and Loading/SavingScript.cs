using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SavingScript
{
    public static void savePlayer(WorkingPlayerData pData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SaveData.Demo";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(pData);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData loadPlayer()
    {
        string path = Application.persistentDataPath + "/SaveData.Demo";
        Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found" + path);
            return null;
        }
    }
}

