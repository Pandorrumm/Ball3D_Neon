using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerSity : MonoBehaviour
{

    public VariableJoystick variableJoystick;

    public float speed = 3f;
    public bool jump = false;
    public bool highJump = false;

    float zPos; // для движения вперёд
    float xPos; // для движения в стороны
    float yPos;
    public float startZPos; //откуда начинается прыжок
    public float startYPos; 

    private float deltaX;
    Rigidbody rb;
    public GameObject gameOverPanel;
    public GameObject particleBallDestroy;
    public CubeSpawner[] cubeSpawners;
    public CubeSpawnerThreeEnemy[] CubeSpawnerThreeEnemy;
    
    private UIManager uIManager;

    private StressReceiver stressReceiver; //shake FX Camera
    SphereCollider sphereCollider;

    private CubeSpawner cubeSpawner;

    [Header("Power Up Speed")]
    public bool powerUpSpeedActive = false;
    public float powerUpSpeed = 5f;
    public float timeDurationPowerUpSpeed; //// продолжительность PowerUpSpeed
    public GameObject pSPowerUpSpeed;
    public GameObject pSWirpDrive;


    [Header("Power Up Shield")]
    public bool powerUpShieldActiv = false;
    public GameObject PowerUpShieldPlayer;
    public GameObject PSDevelopmentUpShield;
    public GameObject PSDestroyShield;

    RotatePlayer rotatePlayer;

    public float timeDurationPowerUpShield; // продолжительность PowerUpShield

    public AudioSource musicLevel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();     
        gameOverPanel.SetActive(false);      
        sphereCollider = GetComponent<SphereCollider>();
        stressReceiver = FindObjectOfType<StressReceiver>();
        cubeSpawner = FindObjectOfType<CubeSpawner>();
        uIManager = FindObjectOfType<UIManager>();       
        rotatePlayer = FindObjectOfType<RotatePlayer>();
        pSPowerUpSpeed.SetActive(false);
        PowerUpShieldPlayer.SetActive(false);
        PSDevelopmentUpShield.SetActive(false);
        PSDestroyShield.SetActive(false);
        pSWirpDrive.SetActive(false);

    }


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
            transform.Translate(13* Time.deltaTime, 0, 0);

        }
        else if (variableJoystick.Horizontal < -0.1f)
        {
            transform.Translate(-13 * Time.deltaTime, 0, 0);
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
            IEnumerator fadeMusicLevel = AudioFadeOut.FadeOut(musicLevel, 0.025f); //уменьшаем громкость музыки
            StartCoroutine(fadeMusicLevel);
            StopCoroutine(fadeMusicLevel);

            SoundManager.PlaySound("Dead");

            Instantiate(particleBallDestroy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameObject.SetActive(false);

            stressReceiver.InduceStress(2f);
            stressReceiver.TraumaExponent = 1f;

            gameOverPanel.SetActive(true);

            for (int i = 0; i <= cubeSpawners.Length - 1; i++)
            {
                cubeSpawners[i].stop = true;
            }

            for (int i = 0; i <= CubeSpawnerThreeEnemy.Length - 1; i++)
            {
                CubeSpawnerThreeEnemy[i].stop = true;
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
            IEnumerator fadeMusicLevel = AudioFadeOut.FadeOut(musicLevel, 0.025f); //уменьшаем громкость музыки
            StartCoroutine(fadeMusicLevel);
            StopCoroutine(fadeMusicLevel);

            SoundManager.PlaySound("Dead");

            Instantiate(particleBallDestroy, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            jump = false;
            highJump = false;
            gameObject.SetActive(false);
            gameOverPanel.SetActive(true);

            for (int i = 0; i <= cubeSpawners.Length - 1; i++)
            {
                cubeSpawners[i].stop = true;
            }
            // pauseButton.gameObject.SetActive(false);
            stressReceiver.InduceStress(2f);
            stressReceiver.TraumaExponent = 1f;

        }

        if (collision.gameObject.tag == "WinsPoint")
        {
            IEnumerator fadeMusicLevel = AudioFadeOut.FadeOut(musicLevel, 0.025f); //уменьшаем громкость музыки
            StartCoroutine(fadeMusicLevel);
            StopCoroutine(fadeMusicLevel);

            SoundManager.PlaySound("Finish");

            // gameObject.SetActive(false);
            //winsText.SetActive(true);
            uIManager.CompleteLevel();
            Invoke("Playerfalse", 1f);
            //pauseButton.gameObject.SetActive(false);
        }


        if (collision.gameObject.tag == "DeadEnemySpawner")
        {

            cubeSpawner.gameObject.SetActive(false);
            //cameraController.CameraBackMove();
        }

        if (collision.gameObject.tag == "PowerUpSpeed")
        {
            SoundManager.PlaySound("TakePowerUp");

            StopCoroutine(PowerUpSpeed());                //Останавливает сопрограмму, если она уже была инициирована
            StartCoroutine(PowerUpSpeed());

            //pSPowerUpSpeed.SetActive(true); //звуковая волна
            //speed = speed + powerUpSpeed;
            //powerUpSpeedActive = true;
            //rotatePlayer.XRotate += 3f;
        }

        if (collision.gameObject.tag == "PowerUpShield")
        {
            SoundManager.PlaySound("TakePowerUp");

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
        pSWirpDrive.SetActive(true);

        // до  yield return new WaitForSeconds(timeDurationPowerUp) - выполняется, потом через 5 секунд выполняется код ниже который   

        yield return new WaitForSeconds(timeDurationPowerUpSpeed);

        speed -= powerUpSpeed;
        rotatePlayer.XRotate -= 3f;
        powerUpSpeedActive = false;
        pSPowerUpSpeed.SetActive(false);
        pSWirpDrive.SetActive(false);
    }

    IEnumerator PowerUpShield()
    {

        powerUpShieldActiv = true;
        PSDevelopmentUpShield.SetActive(true);
        PowerUpShieldPlayer.SetActive(true);

        yield return new WaitForSeconds(timeDurationPowerUpShield);

        SoundManager.PlaySound("DestroyShield");

        PSDestroyShield.SetActive(true);
        powerUpShieldActiv = false;
        PSDevelopmentUpShield.SetActive(false);
        PowerUpShieldPlayer.SetActive(false);

        yield return new WaitForSeconds(1f);
        PSDestroyShield.SetActive(false);
    }



    private void Playerfalse()
    {
        gameObject.SetActive(false);
    }

}
