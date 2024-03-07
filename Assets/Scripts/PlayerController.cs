using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerWalkSpeed, playerRunSpeed;
    public float moveHorizontal,moveVertical;
    private Rigidbody playerRb;
    public GameObject activationObject; 
    public int totalItems = 4; 
    public int collectedItems = 0;
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(moveHorizontal,0,moveVertical);
        playerRb.velocity = playerMovement * playerWalkSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            playerRb.velocity = playerMovement * playerRunSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Coleccionable"))
        {
            Destroy(other.gameObject);
            collectedItems++;
        }
        if (collectedItems >= totalItems)
            {
                if (activationObject != null)
                {
                    activationObject.SetActive(true);
                }
            }
    }
}
