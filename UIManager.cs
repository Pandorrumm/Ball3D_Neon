using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.EventSystems;


public class UIManager : MonoBehaviour
{
    public static int ScreenWidth = Screen.width;
    public static int ScreenHeight = Screen.height;
    //private RotatePlayer rotatePlayer;
    public GameObject restarButtont;
   // public GameObject readyPanel;
   // public GameObject PlayerRotatet;
   // private MovePlayer movePlayer;

    public GameObject completeLevelPanelUI;
    // public GameObject pauseButton;

    public static LevelManager levelManager;

    public static int deadCounter = 0; //счётчик смертей

    public AdMobInterstitial ad;


    public void SavePlayer()
    {
        SaveScript.SavePlayer(levelManager, this);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/gamesaveNeonWay.fun";

        if (File.Exists(path))
        {
            PlayerData data = SaveScript.LoadPlayer();
            LevelManager.countUnlockedLevel = data.countUnlockedLevel;
            deadCounter = data.deadCounter;
        }

        
        //PlayerData data = SaveScript.LoadPlayer();
        //LevelManager.countUnlockedLevel = data.countUnlockedLevel;
        //deadCounter = data.deadCounter;
       
    }

    public void RestartGame()
    {
        deadCounter++;
       // Debug.Log("Счётчик смертей  " + deadCounter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }

    public void AdmobShow()
    {
        if (deadCounter % 3 == 0)
        {
            ad.ShowAds();
           // Debug.Log("Счётчик смертей  "+ deadCounter);
           // Debug.Log("показ баннера");
        }
    }

    public void LevelSelect() // virtual - что бы изменить для последнего уровня в спец скрипте для последнего уровня
    {
        //Если прошли уровень, открываем следующий
        if (SceneManager.GetActiveScene().buildIndex == LevelManager.countUnlockedLevel)
        {
            LevelManager.countUnlockedLevel++;
            //Debug.Log(LevelManager.countUnlockedLevel);
        }
        
        SceneManager.LoadScene("LevelSelect");        
    }

    public void FinishScene()
    {
        SceneManager.LoadScene("FinishScene");
    }

    public void GameMenuScene()
    {
        SceneManager.LoadScene("GameMenu");
    }

    public void LevelSelectScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }

   
    public void ReadyPanel()
    {
        //  pause.pauzePanel.SetActive(false);
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
            
          //  readyPanel.SetActive(false);
          //  restarButtont.SetActive(true);
          //  PlayerRotatet.SetActive(true);
            Time.timeScale = 1;

            // rotatePlayer.XRotate = rotatePlayer.XRotate;
            // SoundManager.PlaySound("CreateBooble");
            //  pauseButton.SetActive(true);
       // }
    }

    public void ExitReadyPanel()
    {        
        SceneManager.LoadScene("LevelSelect");    
    }

    public void Menu()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    
    public void CompleteLevel()
    {
        completeLevelPanelUI.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}



