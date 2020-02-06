using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{


    public static int countUnlockedLevel = 12; //кол-во открытых уровней при старте
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
    
    public void Level1Training()
    {
        SceneManager.LoadScene("Level1Training");
    }
    public void Level2Training()
    {
        SceneManager.LoadScene("Level2Training");
    }
    public void Level3Training()
    {
        SceneManager.LoadScene("Level3Training");
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
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void Level7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void Level8()
    {
        SceneManager.LoadScene("Level8");
    }
    public void Level9()
    {
        SceneManager.LoadScene("Level9");
    }
    public void Level10()
    {
        SceneManager.LoadScene("Level10");
    }
    public void Level11()
    {
        SceneManager.LoadScene("Level11");
    }
    public void Level12()
    {
        SceneManager.LoadScene("Level12");
    }
    public void Level13()
    {
        SceneManager.LoadScene("Level13");
    }
    public void Level14()
    {
        SceneManager.LoadScene("Level14");
    }
    public void Level15()
    {
        SceneManager.LoadScene("Level15");
    }
    public void Level16()
    {
        SceneManager.LoadScene("Level16");
    }
    public void Level17()
    {
        SceneManager.LoadScene("Level17");
    }
    public void Exit()
    {
        Application.Quit();
    }
}

