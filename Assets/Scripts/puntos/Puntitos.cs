using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Puntitos : MonoBehaviour
{
    private AudioSource SonidoPerder;
    // Start is called before the first frame update
    void Start()
    {
        SonidoPerder = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  OnTriggerEnter2D(Collider2D laCosa) 
    {
        if (laCosa.tag == "Player")
        {
            Punto_M.puntajes +=5; 
            Destroy(gameObject);
        }
    }
    
}
