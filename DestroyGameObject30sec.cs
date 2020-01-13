using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject30sec : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 30f);
    }
}
