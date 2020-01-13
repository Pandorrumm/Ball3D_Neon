using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject10sec : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 10f);
    }
}
