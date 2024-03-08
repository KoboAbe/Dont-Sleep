using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del enemigo
    public float detectionRange = 20.0f; // Rango de detección del jugador
    private Transform player; // Posicion del jugador
    public Animator enemyAnim; // Animator del enemigo
    private PlayerController PlayerController;
    public bool stop;
    void Start()
    {
        PlayerController = GetComponent<PlayerController>();
        //POSICION DEL JUGADOR
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        //DIRECCION DEL JUGADOR
        Vector3 directionToPlayer = player.position - transform.position;
        
        //DETECCION DE JUGADOR Y MOVIMIENTO
        if (directionToPlayer.magnitude <= detectionRange)
        {
            enemyAnim.SetBool("IsRun",true);
            directionToPlayer.Normalize();
            transform.position += directionToPlayer * speed * Time.deltaTime;
            transform.LookAt(player);
        }
        else
        {
            enemyAnim.SetBool("IsRun",false);
        }
    
    }

}
