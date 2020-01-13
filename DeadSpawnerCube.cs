using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSpawnerCube : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dead Spawner Cube")
        {
            Destroy(gameObject);
            // Instantiate(puzirInsert.puzirPrefab, objectInsertPositionPuzir, Quaternion.identity);
        }
    }
}