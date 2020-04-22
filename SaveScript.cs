using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;


public static class SaveScript
{   

    public static void SavePlayer(LevelManager levelManager, UIManager uiManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/gamesaveNeonWay.fun";

        FileStream stream = new FileStream(path, FileMode.Create); //Создание файлового потока

        PlayerData data = new PlayerData(levelManager, uiManager); //Получение данных

        formatter.Serialize(stream, data); //Сериализация данных

        stream.Close();

        Debug.Log("сохранили"); 

    }

    public static PlayerData LoadPlayer()
    {

        string path = Application.persistentDataPath + "/gamesaveNeonWay.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            Debug.Log("загрузили");
            return data;           
        }

        else
        {
            Debug.LogError("Save file not found in " + path);
           // Debug.Log("нет сохранений");

            return null;

        }
    }
}
