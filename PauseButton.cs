using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour
{

    public bool isPaused = false;
    public GameObject pauzePanel;

    public void PauseGame()
    {
        //if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // что бы кнопка сработала, а не Плюсом ещё свайп
        //{
        if (!EventSystem.current.IsPointerOverGameObject()) // что бы тач по экрану не срабатывал в режиме паузы
        {


            if (isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
                pauzePanel.SetActive(false);
               

            }
            else

            {

                pauzePanel.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
               
            }
        }

    }

}
