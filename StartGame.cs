using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.IO;

public class StartGame : MonoBehaviour
{
    
    public void StartGameButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    
}
