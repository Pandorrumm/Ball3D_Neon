using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // за кем двигается
    Vector3 offset; //отступ от игрока до камеры


    void Start()
    {
        //фиксируем отступ от камеры до игрока
        offset = player.transform.position - gameObject.transform.position;
    }

    
    void Update()
    {
        //gameObject.transform.position - это положение текущего объекта(камера наша)
        // gameObject.transform.position = player.transform.position - offset;

        
        // Что бы камера При прыжке не подпрыгивала (не меняем позицию по y) 
        if(player.gameObject.GetComponent<MovePlayer>().jump)
        {
            gameObject.transform.position = new Vector3((player.transform.position.x - offset.x) * 0.7f,
                                                     2.5f,
                                                     player.transform.position.z - offset.z);
        }
        else
        {
            //позицию камеры будем менять на 70 % от позиции игрока
            gameObject.transform.position = new Vector3((player.transform.position.x - offset.x) * 0.7f,
                                                         player.transform.position.y - offset.y,
                                                         player.transform.position.z - offset.z);
        }
    }
}
