using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    public float speed = 10.0f;
    private Rigidbody enemyRb;
    private Transform playerCordinate;
    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerCordinate = GameObject.Find("RTI_Gray").GetComponent<Transform>();
    }
   
    void Update()
    {
        Vector3 lookDerection = (playerCordinate.position - transform.position).normalized;
        transform.LookAt(playerCordinate.position);
        enemyRb.AddForce(lookDerection * speed);
    }
}

