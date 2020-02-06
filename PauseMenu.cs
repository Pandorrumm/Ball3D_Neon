using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{


    public static bool GameIsPaused;
    public GameObject pauseMenuUi;
    

   // public AdMobInterstitial ad;

    private void Start()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
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
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // что бы кнопка сработала, а не Плюсом ещё свайп
        {
            pauseMenuUi.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    }

    public void Pause()
    {
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // что бы кнопка сработала, а не Плюсом ещё свайп
        {
            pauseMenuUi.SetActive(true);
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

    public void Restart()
    {
        
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;

        

        // РЕСТАРТ ПО УРОВНЯМ - НЕ для Анимации
        //if (ui.currentLevelIndex == 0)
        //{
        //    Time.timeScale = 1f;
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //}
        //else
        //{
        //    ui.loadLevels = false;           
        //    Instantiate(ui.levels[ui.currentLevelIndex], Vector2.zero, Quaternion.identity);
        //    ui.numberOfBricks = GameObject.FindGameObjectsWithTag("brick").Length;
        //    ui.ball.rb.velocity = Vector2.zero;
        //    ui.ball.inPlay = false;

        //    if (/*Input*/CrossPlatformInputManager.GetButtonDown("Jump") && ui.ball.inPlay == false)
        //    {
        //        ui.ball.rb.isKinematic = false;
        //        ui.ball.rb.AddForce(Vector2.up * ui.ball.speed);
        //        ui.ball.inPlay = true;
        //    }

        //    if (ui.powerUpBullet != null)
        //    {
        //        ui.powerUpBullet.SetActive(false);
        //    }

        //    pauseMenuUi.SetActive(false);
        //    Time.timeScale = 1f;
        //}
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
