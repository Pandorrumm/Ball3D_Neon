using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{


    public static bool GameIsPaused;
    public GameObject pauseMenuUi;
    private PauseButton pauseButton;
    public Animator animator;
    

    // public AdMobInterstitial ad;

    private void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
       // animator = GetComponentInChildren<Animator>(); 
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Continue()
    {
       animator.SetBool("isOpen", false);

        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // что бы кнопка сработала, а не Плюсом ещё свайп
        {
            StopCoroutine(MenuPauseOff());                
            StartCoroutine(MenuPauseOff());
        }

        // if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // что бы кнопка сработала, а не Плюсом ещё свайп
        // {
        //if (pauseMenuUi != null)
        //{
        //    Animator animator = pauseMenuUi.GetComponent<Animator>();

        //    if(animator != null)
        //    {
        //        bool isOpen = animator.GetBool("open");

        //        animator.SetBool("open", !isOpen);
        //    }
        //}

        //Time.timeScale = 1f;
        //GameIsPaused = false;
        // pauseMenuUi.SetActive(false);

        // }

    }

    IEnumerator MenuPauseOff()
    {


        Time.timeScale = 1f;
        GameIsPaused = false;
        yield return new WaitForSeconds(0.5f);
        pauseMenuUi.SetActive(false);

    }

    public void Pause()
    {
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // что бы кнопка сработала, а не Плюсом ещё свайп
        {
            
            pauseMenuUi.SetActive(true);
            animator.SetBool("isOpen", true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void LoadMenu()
    {
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // что бы кнопка сработала, а не Плюсом ещё свайп
        {
            // ad.ShowAds();
            Time.timeScale = 1f;
            SceneManager.LoadScene("LevelSelect");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
