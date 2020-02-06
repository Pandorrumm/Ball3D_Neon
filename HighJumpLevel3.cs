using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighJumpLevel3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.gameObject.GetComponent<MovePlayerLevel3>().startZPos = other.gameObject.transform.position.z;
            other.gameObject.GetComponent<MovePlayerLevel3>().startYPos = other.gameObject.transform.position.y;
            other.gameObject.GetComponent<MovePlayerLevel3>().highJump = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
