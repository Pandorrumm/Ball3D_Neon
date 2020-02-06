using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
{

    //ПЕРВЫЙ ВЫРИАНТ
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f; // порог в процентах
    public float easing = 0.5f;
   
    void Start()
    {
        panelLocation = transform.position;
    }

    public void OnDrag(PointerEventData Data)
    {
        float difference = Data.pressPosition.y - Data.position.y;
        transform.position = panelLocation - new Vector3(0, difference, 0);
    }

    public void OnEndDrag(PointerEventData Data)
    {
        float percentage = (Data.pressPosition.y - Data.position.y) / Screen.width; //percentage - процент
        if(Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if(percentage > 0)
            {
                newLocation += new Vector3(0, -Screen.width, 0);
            }
            else if(percentage < 0)
            {
                newLocation += new Vector3(0, Screen.width, 0);
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds) //плавное движение
    {
        float t = 0f;
        while(t <= 1)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}
