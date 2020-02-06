using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSpawnerCube : MonoBehaviour
{
    public GameObject PSDestroyFromTheShield;

    private void Start()
    {
       // PSDestroyFromTheShield.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dead Spawner Cube")
        {
            Destroy(gameObject);
            
        }

        if (collision.gameObject.tag == "ShieldDestroy")
        {
          //  PSDestroyFromTheShield.SetActive(true);
            Destroy(gameObject);
            Instantiate(PSDestroyFromTheShield, transform.position, Quaternion.identity);
        }

    }
}