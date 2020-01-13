using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private MovePlayer movePlayer;
   // public GameObject restartPosition;

    private void Start()
    {
        movePlayer = FindObjectOfType<MovePlayer>();
    }

    public void RestartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

       // movePlayer.transform.position = restartPosition.transform.position;
      //  movePlayer.gameObject.SetActive(true);
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

    public void Menu()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}



