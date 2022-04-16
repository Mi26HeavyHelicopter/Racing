using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Transform animField;
    [SerializeField] float rotationRate = 1f;
    [SerializeField] float ScaleRate = 1f;

    private bool playerInCheckpoint;
    private float time;
    private Vector3 animVector;
    private SpawnManager spawnManager;
    private void Awake()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    private void Update()
    {
        transform.Rotate(0, rotationRate * Time.deltaTime, 0);
        PlayerAtCheckPoint();
        PlayerLeaveCheckPoint();
    }
  
     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Player")) playerInCheckpoint = true;
     }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInCheckpoint = false;
    }

    private void PlayerAtCheckPoint()
    {
        if (playerInCheckpoint && time <= 5f)
        {
            time += Time.deltaTime;
            float scaleValue = time / 5f;
            animVector = new Vector3(scaleValue, 1.5f, scaleValue);
            animField.localScale = animVector;
           
            
        }
        if (time >= 5)
        {
            Destroy(gameObject);
            spawnManager.checkPointExist = false;
            time = 0;
        }
    }

    private void PlayerLeaveCheckPoint()
    {
        if (!playerInCheckpoint && time > 0)
        {
            time -= Time.deltaTime;
            float scaleValue = time / 5f;
            animVector = new Vector3(scaleValue, 1.5f, scaleValue);
            animField.localScale = animVector;
        }
    }
}