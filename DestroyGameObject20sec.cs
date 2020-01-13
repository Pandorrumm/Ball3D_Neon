using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject20sec : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 20f);
    }
}
