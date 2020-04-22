using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public static int countUnlockedLevel = 1; //кол-во открытых уровней при старте
    //[SerializeField]
    //private Sprite unlockedIcon;
    [SerializeField]
    private Sprite lockedIcon;

    public GameObject[] particleOpenLevels; // particle эффект при открытии уровня

    Animator animator;

    
    public void Start()
    {
   
        animator = GetComponentInChildren<Animator>();

        for (int i = 0; i < transform.childCount; i++) //transform.childCount кол-во дочерних элементов
        {
            if (i < countUnlockedLevel)   // когда открытые уровни
            {
                // transform.GetChild(i).GetComponent<Image>().sprite = unlockedIcon;
                transform.GetChild(i).GetComponent<Button>().interactable = true; //кнопка становится активной, реагирует на нажатие

                SoundManager.PlaySound("OpenLevel");

                particleOpenLevels[i].SetActive(true); // срабатывает эффект при открытии нового тура

                if (i > 0)
                {
                    particleOpenLevels[i - 1].SetActive(false); // чтобы предыдущие уровни не срабатывали при загрузке сцены
                }

                transform.GetChild(i).GetComponent<Animator>().enabled = true;
            }

            else    // когда закрытые уровни
            {
                transform.GetChild(i).GetComponent<Image>().sprite = lockedIcon; // ставим иконку закрытого уровня
                transform.GetChild(i).GetComponent<Image>().color = new Color(255, 0, 0, 255); // что бы закрытые уровни были одного цвета

                transform.GetChild(i).GetComponent<Animator>().enabled = false; // отключаем анимацию цифр

                // transform.GetChild(i).GetComponent<Button>().interactable = false;

                //var button = transform.GetChild(i).GetComponent<Button>();
                //var colors = transform.GetChild(i).GetComponent<Button>().colors;
                //colors.normalColor = new Color(200, 200, 200, 90);
                //transform.GetChild(i).GetComponent<Button>().colors = colors;

                // transform.GetChild(i).transform.localScale = new Vector3(1.6f, 1.3f, 1.4f); // иконку закрытого уровня увеличиваем в размерах

                transform.GetChild(i).GetComponent<Button>().enabled = false; // отключаем кнопку закрытого уровня

                foreach (Transform subchild in transform.GetChild(i))  //ищем 2-ю глубину детей (Image) Чилдрены Чилдренов
                {
                    // Debug.Log(subchild);
                    // subchild.GetComponentInChildren<Image>().enabled = false;
                    subchild.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                }

            }
        }

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
    public void Level18()
    {
        SceneManager.LoadScene("Level18");
    }
    public void Level19()
    {
        SceneManager.LoadScene("Level19");
    }
    public void Level20()
    {
        SceneManager.LoadScene("Level20");
    }
    public void Level21()
    {
        SceneManager.LoadScene("Level21");
    }
    public void Level22()
    {
        SceneManager.LoadScene("Level22");
    }
    public void Level23()
    {
        SceneManager.LoadScene("Level23");
    }
    public void Level24()
    {
        SceneManager.LoadScene("Level24");
    }
    public void Level25()
    {
        SceneManager.LoadScene("Level25");
    }
    public void Level26()
    {
        SceneManager.LoadScene("Level26");
    }
    public void Level27()
    {
        SceneManager.LoadScene("Level27");
    }
    public void Level28()
    {
        SceneManager.LoadScene("Level28");
    }
    public void Level29()
    {
        SceneManager.LoadScene("Level29");
    }
    public void Level30()
    {
        SceneManager.LoadScene("Level30");
    }
    public void Level31()
    {
        SceneManager.LoadScene("Level31");
    }
    public void Level32()
    {
        SceneManager.LoadScene("Level32");
    }
    public void Level33()
    {
        SceneManager.LoadScene("Level33");
    }
    public void Level34()
    {
        SceneManager.LoadScene("Level34");
    }
    public void Level35()
    {
        SceneManager.LoadScene("Level35");
    }
    public void Level36()
    {
        SceneManager.LoadScene("Level36");
    }
    public void Level37()
    {
        SceneManager.LoadScene("Level37");
    }
    public void Level38()
    {
        SceneManager.LoadScene("Level38");
    }
    public void Level39()
    {
        SceneManager.LoadScene("Level39");
    }
    public void Level40()
    {
        SceneManager.LoadScene("Level40");
    }
    public void Level41()
    {
        SceneManager.LoadScene("Level41");
    }
    public void Level42()
    {
        SceneManager.LoadScene("Level42");
    }
    public void Level43()
    {
        SceneManager.LoadScene("Level43");
    }
    public void Level44()
    {
        SceneManager.LoadScene("Level44");
    }
    public void Level45()
    {
        SceneManager.LoadScene("Level45");
    }
    public void Level46()
    {
        SceneManager.LoadScene("Level46");
    }
    public void Level47()
    {
        SceneManager.LoadScene("Level47");
    }
    public void Level48()
    {
        SceneManager.LoadScene("Level48");
    }
    public void Level49()
    {
        SceneManager.LoadScene("Level49");
    }
    public void Level50()
    {
        SceneManager.LoadScene("Level50");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

