using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovePlayerLevel3 : MonoBehaviour
{

    public VariableJoystick variableJoystick;

    public float speed = 3f;
    //public float speedOff = 1f;

    float zPos; // для движения вперёд
    float xPos; // для движения в стороны
    float yPos;
    public float startZPos; //откуда начинается прыжок
    public float startYPos;
    public float amplitudeJump;
    public bool jump = false;
    public bool highJump = false;

    private float deltaX;
    Rigidbody rb;
    // BoxCollider col;

    public GameObject winsText;
    public GameObject gameOverText;
    public GameObject particleBallDestroy;
    public CubeSpawner[] cubeSpawners;
    // public GameObject finishText;

    private UIManager uIManager;

    private StressReceiver stressReceiver;
    SphereCollider sphereCollider;

    private CubeSpawner cubeSpawner;
    // PauseButton pauseButton;

    [Header("Power Up Speed")]
    public float powerUpSpeed = 5f;
    public bool powerUpSpeedActive = false;
    public GameObject pSPowerUpSpeed;

    [Header("Power Up Shield")]
    public bool powerUpShieldActiv = false;
    public GameObject pSPowerUpShield;
    public GameObject PSDevelopmentUpShield;

    RotatePlayer rotatePlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //col = GetComponent<BoxCollider>();
        winsText.SetActive(false);
        gameOverText.SetActive(false);
        //finishText.SetActive(false);
        //SpeedText.text = "Speed =  " + speed * speedOff;
        // moveCubeSpawner = FindObjectOfType<MoveCubeSpawner>();
        sphereCollider = GetComponent<SphereCollider>();
        stressReceiver = FindObjectOfType<StressReceiver>();
        cubeSpawner = FindObjectOfType<CubeSpawner>();
        uIManager = FindObjectOfType<UIManager>();
        // pauseButton = FindObjectOfType<PauseButton>();


      //  ReturnSpeed();




        rotatePlayer = FindObjectOfType<RotatePlayer>();
        pSPowerUpSpeed.SetActive(false);
        pSPowerUpShield.SetActive(false);
        PSDevelopmentUpShield.SetActive(false);


        //  DestroyShild();


    }


    //private readonly float _speed = 0.1f;
    //private Vector2 _startPos;


    void Update()
    {


        //ДЛЯ КЛАВЫ   speedOff = 4 в Unity 

        // перемещение в сек.по оси z
        //zPos += speed * Time.fixedDeltaTime;
        //xPos += Input.GetAxis("Horizontal") * speed * Time.deltaTime * speedOff;


        //if (jump)
        //{

        //    yPos = 0.5f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;

        //    //Debug.Log("Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) = " + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f));
        //    //Debug.Log("yPos = " + yPos);
        //    // Debug.Log("startYPos = " + startYPos);
        //    //Debug.Log("transform.position.z = " + transform.position.z);
        //    //Debug.Log("startZPos = " + startZPos);

        //}

        //else if (highJump)
        //{
        //    yPos = startYPos + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;

        //    //if (yPos > 2)
        //    //{
        //    //    gameObject.GetComponent<Rigidbody>().useGravity = true;
        //    //    highJump = false;
        //    //}
        //    //Debug.Log("yPos = " + yPos);
        //    // Debug.Log("startYPos = " + startYPos);
        //    //Debug.Log("transform.position.y = " + transform.position.y);
        //    //Debug.Log("startYPos = " + startYPos);
        //}
        //else
        //{
        //    yPos = transform.position.y; //оставляем yPos таким же как и есть типа
        //    gameObject.GetComponent<Rigidbody>().useGravity = true;
        //}

        //transform.position = new Vector3(xPos, yPos, zPos);

        ////////////////////////////////////////////////////////////////////////////////////

        //ДЛЯ ТЕЛЕФОНА    speedOff = 2 в Unity 

        if (jump)
        {
            //yPos = 0.6f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
            yPos = 0.36f + Mathf.Sin((transform.position.z - startZPos) / 2f * Mathf.PI / 2f) * amplitudeJump;
        }
        else
        {
            yPos = transform.position.y; //оставляем yPos таким же как и есть типа
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);


        //    if (touch.deltaPosition.x > 0.1)
        //    {
        //        transform.Translate(Vector3.right * Time.deltaTime * 10);  // для тура на плоскости

        //    }
        //    else if (touch.deltaPosition.x < -0.1)
        //    {
        //        transform.Translate(-Vector3.right * Time.deltaTime * 10); //для тура на плоскости
        //    }
        //////////////////////////////////////////////////////
        //if (touch.deltaPosition.x > 0.1)
        //{
        //    transform.Translate(10 * Time.deltaTime, 0, 0);  // для тура на плоскости
        //}
        //else if (touch.deltaPosition.x < -0.1)
        //{
        //    transform.Translate(-10 * Time.deltaTime, 0, 0); //для тура на плоскости
        //}

        //zPos += speed * Time.fixedDeltaTime * speedOff;
        //transform.position = new Vector3(gameObject.transform.position.x, yPos, zPos);



        //джойстик



        if (variableJoystick.Horizontal > 0.1f)
        {
            transform.Translate(8 * Time.deltaTime, 0, 0);

        }
        else if (variableJoystick.Horizontal < -0.1f)
        {
            transform.Translate(-8 * Time.deltaTime, 0, 0);
        }

        //////Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //////rb.AddForce(direction * speed * Time.deltaTime, ForceMode.VelocityChange);

        // zPos += speed * Time.fixedDeltaTime;
        zPos += speed * Time.deltaTime;
        transform.position = new Vector3(gameObject.transform.position.x, yPos, zPos);




    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleUp") || collision.gameObject.CompareTag("Obstacle")) //если столкнулись с препятствием
        {
            Instantiate(particleBallDestroy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameObject.SetActive(false);

            stressReceiver.InduceStress(2f);

            gameOverText.SetActive(true);

            for (int i = 0; i <= cubeSpawners.Length - 1; i++)
            {
                cubeSpawners[i].stop = true;
            }
            // Debug.Log("Стоп спавнер");
            // pauseButton.gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("Floor")) //если столкнулись с полом
        {
            jump = false;
            highJump = false;

        }
        if (collision.gameObject.tag == "DeadZone")
        {
            Instantiate(particleBallDestroy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            jump = false;
            highJump = false;
            gameObject.SetActive(false);
            gameOverText.SetActive(true);

            for (int i = 0; i <= cubeSpawners.Length - 1; i++)
            {
                cubeSpawners[i].stop = true;
            }
            // pauseButton.gameObject.SetActive(false);
            stressReceiver.InduceStress(2f);
        }

        if (collision.gameObject.tag == "WinsPoint")
        {
            // gameObject.SetActive(false);
            winsText.SetActive(true);
            uIManager.CompleteLevel();
            Invoke("Playerfalse", 1f);
            //pauseButton.gameObject.SetActive(false);
        }

        //if (collision.gameObject.tag == "BigCollider")
        //{

        //    //sphereCollider.radius = 1f;
        //    //stressReceiver.InduceStress(1f);
        //    //cameraController.CameraBackMove();
        //}

        if (collision.gameObject.tag == "DeadEnemySpawner")
        {

            cubeSpawner.gameObject.SetActive(false);
            //cameraController.CameraBackMove();
        }

        if (collision.gameObject.tag == "PowerUpSpeed")
        {
            StopCoroutine(PowerUpSpeed());                //Останавливает сопрограмму, если она уже была инициирована
            StartCoroutine(PowerUpSpeed());

            //pSPowerUpSpeed.SetActive(true); //звуковая волна
            //speed = speed + powerUpSpeed;
            //powerUpSpeedActive = true;
            //rotatePlayer.XRotate += 3f;
        }

        if (collision.gameObject.tag == "PowerUpShield")
        {
            //powerUpShieldActiv = true;
            //PSDevelopmentUpShield.SetActive(true);
            //pSPowerUpShield.SetActive(true);

            StopCoroutine(PowerUpShield());                //Останавливает сопрограмму, если она уже была инициирована
            StartCoroutine(PowerUpShield());

        }

    }

    IEnumerator PowerUpSpeed()
    {
        powerUpSpeedActive = true;
        speed = speed + powerUpSpeed;
        rotatePlayer.XRotate += 3f;
        pSPowerUpSpeed.SetActive(true);

        // до  yield return new WaitForSeconds(5f) - выполняется, потом через 5 секунд выполняется код ниже который   
        
        yield return new WaitForSeconds(5f);

        speed -= powerUpSpeed;
        rotatePlayer.XRotate -= 3f;
        powerUpSpeedActive = false;
    }

    IEnumerator PowerUpShield()
    {
        powerUpShieldActiv = true;
        PSDevelopmentUpShield.SetActive(true);
        pSPowerUpShield.SetActive(true);

        yield return new WaitForSeconds(5f);

        powerUpShieldActiv = false;
        PSDevelopmentUpShield.SetActive(false);
        pSPowerUpShield.SetActive(false);

    }

   

    private void Playerfalse()
    {
        gameObject.SetActive(false);
    }



}
