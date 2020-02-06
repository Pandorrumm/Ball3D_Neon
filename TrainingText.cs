using UnityEngine;
using UnityEngine.UI;

public class TrainingText : MonoBehaviour
{

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;

    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Start Of Cubes Up")
        {  
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}

