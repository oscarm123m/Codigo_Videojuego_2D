using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public static bool canpause;
    public static bool isGamePaused = false;
    public AudioSource PauseSong;
    public AudioSource main;
    
    [SerializeField] GameObject Pause;
    void Start()
    {
        Time.timeScale =1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void EscenaJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        Debug.Log("holaaaa");
        main.UnPause();
        PauseSong.Stop();

        Pause.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }
    void PauseGame()
    {
        /*if(!canpause)
        {
            return;
        }*/

        main.Pause();
        PauseSong.Play();
        Pause.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
