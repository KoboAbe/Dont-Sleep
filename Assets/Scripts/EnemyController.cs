using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f; // Velocidad de movimiento del enemigo
    public float detectionRange = 5.0f; // Rango de detección del jugador
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        
        if (directionToPlayer.magnitude <= detectionRange)
        {
            
            directionToPlayer.Normalize();

            
            transform.position += directionToPlayer * speed * Time.deltaTime;

            
            transform.LookAt(player);
        }
        
    }

}
