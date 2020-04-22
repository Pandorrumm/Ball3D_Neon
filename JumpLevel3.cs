using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLevel3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.PlaySound("Jump");
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<MovePlayerLevel3>().startZPos = other.gameObject.transform.position.z;
            //other.gameObject.GetComponent<MovePlayerLevel3>().startYPos = other.gameObject.transform.position.y;
            other.gameObject.GetComponent<MovePlayerLevel3>().jump = true;
            
        }
    }
}
