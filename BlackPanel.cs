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
        LevelManager.countUnlockedLevel = 1;
    }   

    public void DestroyBlackPanel()
    {
        blackPanel.SetActive(false);
    }
    
}
