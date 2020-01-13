using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public float XRotate;
    
    void Update()
    {
        transform.Rotate(new Vector3(XRotate, 0,0));
    }
}
