using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour

{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUi;



    // Start is called before the first frame update

    public void pausar()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("se hizo clic");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("se hizo clic");
    }

    public void salirJuego()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gameIsPaused = false;
        Debug.Log("se hizo clic");
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if(gameIsPaused){
                resume();
            }
            else
            {
                pausar();
            }
    }
}
}
