using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPanel : MonoBehaviour
{
    public GameObject blackPanel;

    void Start()
    {
        blackPanel.SetActive(true);
        Invoke("DestroyBlackPanel", 2f);
    }   

    public void DestroyBlackPanel()
    {
        blackPanel.SetActive(false);
    }
    
}
