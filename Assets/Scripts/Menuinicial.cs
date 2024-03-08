using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuinicial : MonoBehaviour
{
    public Canvas menuInicio;
    public Canvas lore;

    // Start is called before the first frame update
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CanvasOff(){
        menuInicio.gameObject.SetActive(false);
        lore.gameObject.SetActive(true);
    }

    void Start()
    {
        
        Debug.Log("Salir...");
    }

    // Update is called once per frame
    void Update()
    {
    

    }
}
