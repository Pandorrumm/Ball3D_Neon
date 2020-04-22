using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager50Level : UIManager
{
    public override void LevelSelect()
    {
        SceneManager.LoadScene("FinishScene");
    }
}
