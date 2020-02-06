using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUp : MonoBehaviour
{
    public float UpSpeed = 1f; //скорость поднятья куба из под земли
    public bool toUp = false;
    // public Transform target;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(toUp && transform.position.y < 0.1f)
        {
             transform.Translate(Vector3.up * Time.fixedDeltaTime * UpSpeed );
            
           // transform.Translate(new Vector3(transform.position.x, transform.position.y- 2f, transform.position.z) * Time.fixedDeltaTime * UpSpeed);

        }
         
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Start Of Cubes Up")) //если препятствия коснётся что то с тегом "Start Of Cubes Up"
        {
            toUp = true;
        }
    }
}
