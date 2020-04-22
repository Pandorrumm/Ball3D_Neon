using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnerThreeEnemy : MonoBehaviour
{

    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait; // Наибольшее ожидание
    public float spawnLeastWait; //Наименьшее ожидание
    public float spawnPositionY; //позиция по оси y
    public int startWait;
    public bool stop;

    int randEnemy;

    private GameObject[] clone;

    void Start()
    {
        StartCoroutine(WaitSpawner());
    }


    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);

    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randEnemy = Random.Range(0, 3); //что бы разные кубы появлялись рандомно

            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnPositionY, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }

        clone = GameObject.FindGameObjectsWithTag("ObstacleUp");
        // Debug.Log(clone);

        for (int i = 0; i <= clone.Length - 1; i++)
        {
            Destroy(clone[i]);

        }

    }
}
