using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    private void Start()
    {
        // readyPanel.SetActive(true);
        // restarButtont.SetActive(false);
        //  Time.timeScale = 0;
        //  PlayerRotatet.SetActive(false);
        // movePlayer = FindObjectOfType<MovePlayer>();
       // pauseButton.SetActive(false);
    }

    public void RestartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void LevelSelect()
    {
        //Если прошли уровень это нужно вставить, что бы открылся следующий
        if (SceneManager.GetActiveScene().buildIndex == LevelManager.countUnlockedLevel)
        {
            LevelManager.countUnlockedLevel++;
            Debug.Log(LevelManager.countUnlockedLevel);
        }

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

}



