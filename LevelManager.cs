using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{


    public static int countUnlockedLevel = 1; //кол-во открытых уровней при старте
    private Sprite unlockedIcon;
    private Sprite lockedIcon;



    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) //transform.childCount кол-во дочерних элементов
        {
            if (i < countUnlockedLevel)
            {
                // transform.GetChild(i).GetComponent<Image>().Sprite = unlockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = true;
            }
            else
            {
                // transform.GetChild(i).GetComponent<Image>().Sprite = lockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = false;

            }
        }
    }

    void Update()
    {

    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }


    public void Exit()
    {
        Application.Quit();
    }
}

