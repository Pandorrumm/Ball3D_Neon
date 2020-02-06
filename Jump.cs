using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<MovePlayer>().startZPos = other.gameObject.transform.position.z;
            other.gameObject.GetComponent<MovePlayer>().jump = true;           
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

}
