using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int countUnlockedLevel;
    public int deadCounter;

    public PlayerData(LevelManager levelManager, UIManager uiManager)
    {
        countUnlockedLevel = LevelManager.countUnlockedLevel;
        deadCounter = UIManager.deadCounter;
    }
}
