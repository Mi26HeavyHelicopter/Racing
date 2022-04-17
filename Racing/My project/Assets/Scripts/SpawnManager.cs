using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject prefabCheckPoint;
    [SerializeField] List<GameObject> policeCar;
    [HideInInspector] public GameObject checkPoint;
    public bool checkPointExist = false;

    private void Update()
    {
        CreateCheckPoint();
    }
    private void CreateCheckPoint()
    {
        if (!checkPointExist)
        {
           checkPoint = Instantiate(prefabCheckPoint, GenerateSpawnPos(), prefabCheckPoint.transform.rotation);
           checkPointExist = true;
           SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(policeCar[GenerateRandomEnemy()], GenerateSpawnPos(), policeCar[GenerateRandomEnemy()].transform.rotation);
    }
    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-90, 93); 
        float spawnPosZ = Random.Range(-102, 110);
        Vector3 randomPos = new Vector3(spawnPosX, 0.1f, spawnPosZ);
        return randomPos;
    }

    private int GenerateRandomEnemy()
    {
        return Random.Range(0, 1);
    }
}
