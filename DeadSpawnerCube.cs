using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSpawnerCube : MonoBehaviour
{
    public GameObject PSDestroyFromTheShield;
    private StressReceiver stressReceiver; //shake FX Camera
    private MovePlayerLevel3 playerLevel3;
    private MovePlayerSity playerSity;

    private void Start()
    {
        stressReceiver = FindObjectOfType<StressReceiver>();
        playerLevel3 = FindObjectOfType<MovePlayerLevel3>();
        playerSity = FindObjectOfType<MovePlayerSity>();


    }
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Dead Spawner Cube")
        {
            // Destroy(gameObject);
            gameObject.SetActive(false);
            
        }

        if (collision.gameObject.tag == "ShieldDestroy")
        {
            SoundManager.PlaySound("DestroyObstacleFromTheShield");
            StopCoroutine(DestroyCubesWithAShield());                //Останавливает сопрограмму, если она уже была инициирована
            StartCoroutine(DestroyCubesWithAShield());
            
        }

    }

    IEnumerator DestroyCubesWithAShield()
    {
        gameObject.SetActive(false);
       // Destroy(gameObject);
       // PSDestroyFromTheShield.SetActive(true);
        stressReceiver.TraumaExponent = 15f; //что бы тряска небольшая была
        stressReceiver.InduceStress(2f);
        Instantiate(PSDestroyFromTheShield, transform.position, Quaternion.identity);


        yield return new WaitForSeconds(10);
        //if (!playerLevel3.powerUpShieldActiv)
        //{
            stressReceiver.TraumaExponent = 1f; // что бы большая тряска вернулась после уничтожения щита
            Debug.Log("Увеличиваем назад тряску");

        
        

        yield return null;


    }

}
