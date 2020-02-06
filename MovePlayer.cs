
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MovePlayer : MonoBehaviour
{

 //   [Range(0f, 10f)] // что бы скорость менять слайдером в Unity
    public float speed = 3f;
    // public float speedOff = 1f;
    
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
    public GameObject gameOverText;

    //public bool directionChosen;
    //public Vector3 direction;

    //public Transform target;
    //private Vector3 offset;
    //private float distance;

    //private readonly float _speed = 1f;
    //private Vector2 _startPos;

    public GameObject particleBallDestroy;

    public CubeSpawner[] cubeSpawners;

    //private MoveCubeSpawner moveCubeSpawner;

    //CharacterController cc;
    Vector3 moveVec; //направление движения
    //Vector3 gravity;
    //int laneNumber = 1; //номер текущей линии
    //int lanesCount = 4; // кол-во линий  0,1,2,3,4
    //public float FirstLanePos; // позиция нулевой линии
    //public float LaneDistance; // расстояние между линиями
    //public float SideSpeed; // скорость перемещения с одной линии на другую

    //bool didChangeLastFrame = false; //нажата или отжата кнопка
    //float jumpSpeed = 4;


    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startPlayerPosition, endPlayerPosition;
    private float swipeTime;
    public float swipeDuration = 0.1f; //продолжительность
    public float maxWidthSwipe = 2.88f; // max ширина дороги для свайпа
    public float stepSwipe = 0.96f; // шаг влево вправо какой будет
    public float stepZforward = 0.5f; // шаг вперед при свайпе по оси z

    private UIManager uIManager;

    private StressReceiver stressReceiver;

    SphereCollider sphereCollider;

    // CameraController cameraController;

    GameObject[] deadZone;

   // PauseButton pauseButton;




    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        // col = GetComponent<BoxCollider>();
        winsText.SetActive(false);
        gameOverText.SetActive(false);
        uIManager = FindObjectOfType<UIManager>();
        //cc = GetComponent<CharacterController>();

        ////определяем вектор направления
        //moveVec = new Vector3(0, 0, 1); //направление по z оси  у нас
        //gravity = Vector3.zero;
        stressReceiver = FindObjectOfType<StressReceiver>();
        sphereCollider = GetComponent<SphereCollider>();
        // cameraController = FindObjectOfType<CameraController>();
        deadZone = GameObject.FindGameObjectsWithTag("DeadZone");
       // pauseButton = FindObjectOfType<PauseButton>();

    }

    void Update()
    {

        //if(cc.isGrounded)
        //{
        //    gravity = Vector3.zero;

        //    if(Input.GetAxisRaw("Vertical") > 0)
        //    {
        //        gravity.y = jumpSpeed;
        //    }
        //}
        //else
        //{
        //    gravity += Physics.gravity * Time.deltaTime * 2;
        //}

        //moveVec.z = speed;
        //moveVec *= Time.deltaTime;

        //moveVec += gravity;

        //float input = Input.GetAxis("Horizontal");

        //if(Mathf.Abs(input) > .1f)
        //{
        //    if (!didChangeLastFrame)
        //    {
        //        didChangeLastFrame = true;
        //        //если нажата кнопка влево, то input будет отрицательным, если нажата кнопка вправо, то input будет положительным
        //        laneNumber += (int)Mathf.Sign(input);

        //        //ограничиваем laneNumber от 0 и до кол-ва линий
        //        laneNumber = Mathf.Clamp(laneNumber, 0, lanesCount);
        //    }

        //}
        //else
        //{
        //    didChangeLastFrame = false;
        //}

        ////горизонтальное перемещение игрока
        //Vector3 newPos = transform.position;
        //newPos.x = Mathf.Lerp(newPos.x, FirstLanePos + (laneNumber * LaneDistance), Time.deltaTime * SideSpeed);
        //transform.position = newPos;

        //cc.Move(moveVec); // функция из CharacterController



        //ДЛЯ КЛАВЫ   speedOff = 4 в Unity 

        // перемещение в сек.по оси z
        //zPos += speed * Time.fixedDeltaTime;
        //xPos += Input.GetAxis("Horizontal") * speed * Time.deltaTime * 3;

        //if (jump)
        //{
        //    yPos = 0.5f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
        //}
        //else
        //{
        //    yPos = transform.position.y; //оставляем yPos таким же как и есть типа
        //    gameObject.GetComponent<Rigidbody>().useGravity = true;
        //}

        //transform.position = new Vector3(xPos, yPos, zPos);



        //ДЛЯ ТЕЛЕФОНА    speedOff = 1 в Unity 

        //if (jump)
        //{
        //    //yPos = 0.36f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
        //     yPos = 0.65f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
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
        //         transform.Translate(4f * Time.deltaTime, 0, 0);
        //        //transform.Translate(10 * Time.deltaTime, 0, 0);  // для тура на плоскости
        //    }
        //    else if (touch.deltaPosition.x < 0)
        //    {
        //        transform.Translate(-4f * Time.deltaTime, 0, 0);
        //        //transform.Translate(-10 * Time.deltaTime, 0, 0); //для тура на плоскости
        //    }
        //}
        //zPos += speed * Time.fixedDeltaTime * speedOff;
        //transform.position = new Vector3(gameObject.transform.position.x, yPos, zPos);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        //ДЛЯ ТЕЛЕФОНА    speedOff = 1 в Unity  SWIPE

        //if (pauseButton.isPaused)
        //{
           
        //    //return;
        //}
        
        if (jump)
        {
            //yPos = 0.36f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
            yPos = 0.65f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
        }

        else
        {
            yPos = transform.position.y; //оставляем yPos таким же как и есть типа
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        //if(pauseButton.isPaused)
        if (!EventSystem.current.IsPointerOverGameObject()) // что бы тач по экрану не срабатывал в режиме паузы
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {

                startTouchPosition = Input.GetTouch(0).position;

            }



            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {

                endTouchPosition = Input.GetTouch(0).position;

                if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -maxWidthSwipe)
                {
                    StartCoroutine(Swipe("left"));

                }
                if ((endTouchPosition.x > startTouchPosition.x) && transform.position.x < maxWidthSwipe)
                {
                    StartCoroutine(Swipe("right"));

                }

            }

        }
            // zPos += speed * Time.fixedDeltaTime;
            zPos += speed * Time.deltaTime;
            transform.position = new Vector3(gameObject.transform.position.x, yPos, zPos);
        

    }

    private IEnumerator Swipe(string whereToSwipe)
    {

        switch (whereToSwipe)
        {
            case "left":
                swipeTime = 0f;
                startPlayerPosition = transform.position;
                endPlayerPosition = new Vector3(startPlayerPosition.x - stepSwipe, transform.position.y,
                                                transform.position.z + stepZforward);

                while (swipeTime < swipeDuration)
                {
                    swipeTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPlayerPosition, endPlayerPosition, swipeTime / swipeDuration);
                    yield return null;
                }
                break;

            case "right":
                swipeTime = 0f;
                startPlayerPosition = transform.position;
                endPlayerPosition = new Vector3(startPlayerPosition.x + stepSwipe, transform.position.y,
                                                transform.position.z + stepZforward);

                while (swipeTime < swipeDuration)
                {
                    swipeTime += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPlayerPosition, endPlayerPosition, swipeTime / swipeDuration);
                    yield return null;
                }
                break;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleUp") || collision.gameObject.CompareTag("Obstacle")) //если столкнулись с препятствием
        {
            Instantiate(particleBallDestroy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameObject.SetActive(false);

            stressReceiver.InduceStress(2f);

            gameOverText.SetActive(true);

            for (int i = 0; i <= cubeSpawners.Length-1; i++)
            {
                cubeSpawners[i].stop = true;               
            }
           // pauseButton.gameObject.SetActive(false);
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
            stressReceiver.InduceStress(2f);
            gameOverText.SetActive(true);

        }

        if (collision.gameObject.tag == "WinsPoint")
        {
            // gameObject.SetActive(false);
            Invoke("Playerfalse", 2f);
            //winsText.SetActive(true);
            uIManager.CompleteLevel();
            
            deadZone[0].SetActive(false);
        }

        //if (collision.gameObject.tag == "ActivationFinish")
        //{
        //    finish.SetActive(true);
        //}

        if (collision.gameObject.tag == "BigCollider")
        {
            
            sphereCollider.radius = 1f;
           // stressReceiver.InduceStress(1f);
            //cameraController.CameraBackMove();
        }

    }

    private void Playerfalse()
    {
        gameObject.SetActive(false);
    }
}
