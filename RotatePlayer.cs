
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{

    public float XRotate;
    public float YRotate = 0f;
    public float ZRotate = 0f;

    // PauseButton pauseButton;
   // MovePlayerLevel3 playerLevel3;

    void Start()
    {
        // pauseButton = FindObjectOfType<PauseButton>();

        //playerLevel3 = FindObjectOfType<MovePlayerLevel3>();
    }
    void Update()
    {
        //if (!pauseButton.isPaused)
        //{
            transform.Rotate(new Vector3(XRotate, YRotate, ZRotate));
        //}

        
    }

    
}
