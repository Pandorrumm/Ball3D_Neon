using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLevel3 : MonoBehaviour
{
    public GameObject player; // за кем двигается
    Vector3 offset; //отступ от игрока до камеры
    //MovePlayerLevel3 playerLevel3;



    void Start()
    {
        //фиксируем отступ от камеры до игрока
        offset = player.transform.position - gameObject.transform.position;

       // playerLevel3 = FindObjectOfType<MovePlayerLevel3>();
    }


    void Update()
    {
        //gameObject.transform.position - это положение текущего объекта(камера наша)
        // gameObject.transform.position = player.transform.position - offset;


        // Что бы камера При прыжке не подпрыгивала (не меняем позицию по y) 
        if (player.gameObject.GetComponent<MovePlayerLevel3>().jump)
        {
            gameObject.transform.position = new Vector3((player.transform.position.x - offset.x) * 0.8f,
                                                     2.5f,
                                                     player.transform.position.z - offset.z);
        }
        else
        {
            //позицию камеры будем менять на 90 % от позиции игрока
            gameObject.transform.position = new Vector3((player.transform.position.x - offset.x) *1f,
                                                         player.transform.position.y - offset.y,
                                                         player.transform.position.z - offset.z);
        }

        if (player.gameObject.GetComponent<MovePlayerLevel3>().highJump)
        {
            gameObject.transform.position = new Vector3((player.transform.position.x - offset.x) * 0.8f,
                                                     4.5f,
                                                     player.transform.position.z - offset.z);
        }
        else
        {
            //позицию камеры будем менять на 90 % от позиции игрока
            gameObject.transform.position = new Vector3((player.transform.position.x - offset.x) * 1f,
                                                         player.transform.position.y - offset.y,
                                                         player.transform.position.z - offset.z);
        }

        //if (playerLevel3.powerUpSpeedActive == true)
        //{
           
        //}
    }
}
