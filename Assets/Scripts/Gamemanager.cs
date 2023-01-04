using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    public Renderer fondo;

    public GameObject menuInicio;
    public GameObject menuGameOver;
    public bool start = false;
    public bool gameOver = false;
    

    public List<GameObject> obstaculo;
    // Start is called before the first frame update
    void Start()
    {
        // crear calabera
    
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && !gameOver)
        {
            menuInicio.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        else if(gameOver)
        {
            menuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            menuInicio.SetActive(false);
            menuInicio.SetActive(false);
        fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.010f, 0) * Time.deltaTime;
        }
    }

}
