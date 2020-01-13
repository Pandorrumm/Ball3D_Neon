using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeSpawner : MonoBehaviour
{

    public float speed;
    public Vector3 dir;

    private void FixedUpdate()
    {
        transform.Translate(speed * dir * Time.deltaTime, Space.World);
    }
}
