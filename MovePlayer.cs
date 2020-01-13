using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{

 //   [Range(0f, 10f)] // что бы скорость менять слайдером в Unity
    public float speed = 3f;
    public float speedOff = 1f;

    float zPos; // для движения вперёд
    float xPos; // для движения в стороны
    float yPos;
    public float startZPos; //откуда начинается прыжок
    public float amplitudeJump;
    public bool jump = false;

    private float deltaX;
    Rigidbody rb;
    BoxCollider col;

    public GameObject winsText;

    //public bool directionChosen;
    //public Vector3 direction;

    //public Transform target;
    //private Vector3 offset;
    //private float distance;

    //private readonly float _speed = 1f;
    //private Vector2 _startPos;

    public GameObject particleBallDestroy;

    public Text SpeedText;

    


    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //col = GetComponent<BoxCollider>();
        winsText.SetActive(false);
        //SpeedText.text = "Speed =  " + speed * speedOff;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        //ДЛЯ КЛАВЫ
        // перемещение в сек.по оси z
        zPos += speed * Time.fixedDeltaTime;
        xPos += Input.GetAxis("Horizontal") * speed * Time.deltaTime * speedOff;

        if (jump)
        {
            yPos = 0.5f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
        }
        else
        {
            yPos = transform.position.y; //оставляем yPos таким же как и есть типа
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        transform.position = new Vector3(xPos, yPos, zPos);

        

        //ДЛЯ ТЕЛЕФОНА



        //if (jump)
        //{
        //    yPos = 0.36f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
        //}
        //else
        //{
        //    yPos = transform.position.y; //оставляем yPos таким же как и есть типа
        //    gameObject.GetComponent<Rigidbody>().useGravity = true;
        //}
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.deltaPosition.x > 0)
        //    {
        //        transform.Translate(3 * Time.deltaTime, 0, 0);

        //    }
        //    else if (touch.deltaPosition.x < 0)
        //    {
        //        transform.Translate(-3 * Time.deltaTime, 0, 0);

        //    }
        //}
        //zPos += speed * Time.fixedDeltaTime * speedOff;
        //transform.position = new Vector3(gameObject.transform.position.x, yPos, zPos);



        // // transform.position = new Vector3(xPos, yPos, zPos);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        Vector3 point = hit.point;
        //        point.z = gameObject.transform.position.z;
        //        point.y = gameObject.transform.position.y;
        //        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, point, 1f);

        //    }
        //}
        //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 1f), speed);


        //if (Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && target != null)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    target.position = ray.origin + ray.direction * distance + offset;
        //}
        //if (Input.GetMouseButtonUp(0))
        // target = null;


        //if (Input.touchCount > 0)
        //{
        //    var touch = Input.GetTouch(0);

        //    switch (touch.phase)
        //    {
        //        case TouchPhase.Began:
        //            _startPos = touch.position;
        //            break;

        //        case TouchPhase.Moved:
        //            var dir = touch.position - _startPos;
        //            var pos = transform.position + new Vector3(dir.x, 0, 0);
        //            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * _speed);
        //            break;
        //    }
        //}
    }
   


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleUp")) //если столкнулись с препятствием
        {
            Instantiate(particleBallDestroy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameObject.SetActive(false);

            
        }
        else if (collision.gameObject.CompareTag("Floor")) //если столкнулись с полом
        {
            jump = false;
        }
        if (collision.gameObject.tag == "DeadZone")
        {
            Instantiate(particleBallDestroy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            jump = false;
            gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "WinsPoint")
        {
           
            gameObject.SetActive(false);
            winsText.SetActive(true);

        }

    }
}
