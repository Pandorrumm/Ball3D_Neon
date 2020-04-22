using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevelPanel : MonoBehaviour
{

    void Start()
    {
        //if (LevelManager.countUnlockedLevel == 16 || LevelManager.countUnlockedLevel == 31 || 
        //    LevelManager.countUnlockedLevel == 46)
        if (LevelManager.countUnlockedLevel > 15)
        {
            gameObject.transform.Translate(0, -Screen.height , 0);
           
        }

        if (LevelManager.countUnlockedLevel > 30)
        {
            gameObject.transform.Translate(0, -Screen.height, 0);
            
        }

        if (LevelManager.countUnlockedLevel > 45)
        {
            gameObject.transform.Translate(0, -Screen.height, 0);
            
        }
    }

    
}
