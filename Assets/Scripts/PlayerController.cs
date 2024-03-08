using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerWalkSpeed, playerRunSpeed, rotationSpeed; // Velocidades del movimiento al caminar, correr y rotar respectivamente
    private float moveHorizontal,moveVertical; // Movimiento en el eje horizontal y vertical
    public GameObject activationObject; // Objeto de puerta, se activa al recolectar todos los coleccionables
    public int totalItems = 4; // Total coleccionables
    public int collectedItems = 0; // Cantidad actual de coleccionables
    public Animator playerAnimator; // Animator del jugador

    public bool isPlaying; // El jugador esta jugando
    public AudioSource steps;
    public AudioSource sprintSteps;
    public Canvas over,win;
    

    void Start()
    {
        isPlaying = true;
    }

    
    void Update()
    {

        if(isPlaying)
        {
            //MOVIMIENTO EN EL EJE HORIZONTAL Y VERTICAL
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical"); 

            //MOVIMIENTO DEL JUGADOR
            transform.Translate(Vector3.forward * moveVertical * playerWalkSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveHorizontal * playerWalkSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotationSpeed * moveHorizontal * playerWalkSpeed * Time.deltaTime);

            //CONTROLADORES DE ANIMACIÓN
            playerAnimator.SetFloat("VelX",moveHorizontal);
            playerAnimator.SetFloat("VelY",moveVertical);

            //MECANICA DE CORRER
            if(Input.GetKey(KeyCode.LeftShift))
            {
                //CONTROLADORES DE ANIMACIÓN
                playerAnimator.SetBool("IsRun",true);

                //MOVIMIENTO DEL JUGADOR CON playerRunSpeed
                transform.Translate(Vector3.forward * moveVertical * playerRunSpeed * Time.deltaTime);
                transform.Translate(Vector3.right * moveHorizontal * playerRunSpeed * Time.deltaTime);
                transform.Rotate(Vector3.up * rotationSpeed * moveHorizontal * playerRunSpeed * Time.deltaTime);
            }else 
            {
                //CONTROLADORES DE ANIMACIÓN
                playerAnimator.SetBool("IsRun",false);
            } 

            if(moveHorizontal >= 1 || moveHorizontal <= -1 || moveVertical >= 1 || moveVertical <= -1)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    steps.enabled = false;
                    sprintSteps.enabled = true;
                }
                else
                {
                    steps.enabled = true;
                    sprintSteps.enabled = false;
                }
            }
            else
            {
                steps.enabled = false;
                sprintSteps.enabled = false;
            
        }
    

}
    }

    void OnCollisionEnter(Collision other)
    {
        //DETECCIÓN DE GAME OVER
        if(other.gameObject.CompareTag("Enemy"))
        {
            playerAnimator.SetBool("GameOver",true);
            Debug.Log("Game Over");
            isPlaying = false;
            over.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerEnter(Collider other) {

        //DETECCION DE ADQUISICIÍN DE UN COLECCIONABLE
        if(other.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
            collectedItems++;
        }
        //CONDICION DE VICTORIA
        if (collectedItems >= totalItems)
            {
                if (activationObject != null)
                {
                    activationObject.SetActive(true);
                }
            }
        if (other.CompareTag("Door"))
        {
            SceneManager.LoadScene(2);
        }
        if (other.CompareTag("Door2"))
        {
            win.gameObject.SetActive(true);
        }
    }
}
