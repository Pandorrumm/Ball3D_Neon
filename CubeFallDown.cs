using UnityEngine;

public class CubeFallDown : MonoBehaviour
{
   
    void Start()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshRenderer>().enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FallDownCude")) //если препятствия коснётся что то с тегом "FallDownCude"
        {           
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
        
    }
}

