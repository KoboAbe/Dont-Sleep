using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerWalkSpeed, playerRunSpeed, rotationSpeed;
    private float moveHorizontal,moveVertical;
    public GameObject activationObject; 
    public int totalItems = 4; 
    public int collectedItems = 0;
    public Animator playerAnimator;
    public Rigidbody playerRb;

    
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveVertical * playerWalkSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * moveHorizontal * playerWalkSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * moveHorizontal * playerWalkSpeed * Time.deltaTime);
        playerAnimator.SetFloat("VelX",moveHorizontal);
        playerAnimator.SetFloat("VelY",moveVertical);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("IsRun",true);
            transform.Translate(Vector3.forward * moveVertical * playerRunSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * moveHorizontal * playerRunSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotationSpeed * moveHorizontal * playerRunSpeed * Time.deltaTime);
        }else 
        {
            playerAnimator.SetBool("IsRun",false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            playerAnimator.SetBool("GameOver",true);
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
