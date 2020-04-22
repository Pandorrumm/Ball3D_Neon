using UnityEngine;

public class CubeFallDown : MonoBehaviour
{
    //public GameObject particleFallDown;

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
            // Instantiate(particleFallDown, gameObject.transform.position, Quaternion.identity); 
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {         
            SoundManager.PlaySound("CubeFallDown");
        }
    }
}

