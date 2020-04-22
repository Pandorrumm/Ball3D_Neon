using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, swipeSound, deadSound, takePowerUpSound, shieldCreationSound,
                            destroyShieldSound, finishSound, openLevelSound, destroyObstacleFromTheShieldSound,
                            obstacleUpSound, cubeFallDownSound, moveCubeLeftRightSound;
    static AudioSource myMusic;
    
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        swipeSound = Resources.Load<AudioClip>("Swipe");
        deadSound = Resources.Load<AudioClip>("Dead");
        takePowerUpSound = Resources.Load<AudioClip>("TakePowerUp");
        shieldCreationSound = Resources.Load<AudioClip>("ShieldCreation");
        destroyShieldSound = Resources.Load<AudioClip>("DestroyShield");
        finishSound = Resources.Load<AudioClip>("Finish");
        openLevelSound = Resources.Load<AudioClip>("OpenLevel");
        destroyObstacleFromTheShieldSound = Resources.Load<AudioClip>("DestroyObstacleFromTheShield");
        obstacleUpSound = Resources.Load<AudioClip>("ObstacleUp");
        cubeFallDownSound = Resources.Load<AudioClip>("CubeFallDown");
        moveCubeLeftRightSound = Resources.Load<AudioClip>("MoveCubeLeftRight");


        myMusic = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                myMusic.PlayOneShot(jumpSound);
                break;
            case "Swipe":
                myMusic.PlayOneShot(swipeSound);
                break;
            case "Dead":
                myMusic.PlayOneShot(deadSound);
                break;
            case "TakePowerUp":
                myMusic.PlayOneShot(takePowerUpSound);
                break;
            case "ShieldCreation":
                myMusic.PlayOneShot(shieldCreationSound);
                break;
            case "DestroyShield":
                myMusic.PlayOneShot(destroyShieldSound);
                break;
            case "Finish":
                myMusic.PlayOneShot(finishSound);
                break;
            case "OpenLevel":
                myMusic.PlayOneShot(openLevelSound);
                break;
            case "DestroyObstacleFromTheShield":
                myMusic.PlayOneShot(destroyObstacleFromTheShieldSound);
                break;
            case "ObstacleUp":
                myMusic.PlayOneShot(obstacleUpSound);
                break;
            case "CubeFallDown":
                myMusic.PlayOneShot(cubeFallDownSound);
                break;
            case "MoveCubeLeftRight":
                myMusic.PlayOneShot(moveCubeLeftRightSound);
                break;
        }
    }
}
