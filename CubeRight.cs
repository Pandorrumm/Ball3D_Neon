using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRight : MonoBehaviour
{
    public float UpSpeed = 1f; //скорость поднятья куба из под земли
    public bool toRight = false;
    // public Transform target;

    void Start()
    {

    }


    void Update()
    {
        if (toRight && transform.position.y < 0.6f)
        {
            transform.Translate(Vector3.right * Time.fixedDeltaTime * UpSpeed);

            // transform.Translate(new Vector3(transform.position.x + 1, transform.position.y , transform.position.z) * Time.fixedDeltaTime * UpSpeed);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Start Of Cubes Up")) //если препятствия коснётся что то с тегом "Start Of Cubes Up"
        {
            toRight = true;
        }
    }
}
