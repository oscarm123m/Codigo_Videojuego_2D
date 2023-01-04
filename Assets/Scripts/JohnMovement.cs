using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class JohnMovement : MonoBehaviour
{
    public Gamemanager gameManager;
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;
    public bool start = false;
    public bool gameOver = false;
    public GameObject calabera;
    public GameObject calabera2;
    public GameObject puas1;
    public GameObject puas2;
    public GameObject filo;
    public GameObject caidainicial;
    public GameObject caida;
    public GameObject caida1;
    public GameObject caida2;
    public GameObject caida3;
    public GameObject caida4;
    public GameObject caidafinal;
    public GameObject bullet;

    public GameObject menuInicio;
    public GameObject menuGameOver;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 5;

    private AudioSource SonidoDeSalto;
    private AudioSource SonidoPerder;

    public List<GameObject> obstaculo;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        SonidoDeSalto = GetComponent<AudioSource>();
        SonidoPerder = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstaculo")
        {
            SonidoPerder.Play();
            gameManager.gameOver = true;
            
        }
    }
    

    private void Update()
    {
        if (!start && !gameOver)
        {
            menuInicio.SetActive(true);
            Punto_M.puntajes =0;
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
        
        // Movimiento
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f);

        // Detectar Suelo
        // Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            SonidoDeSalto.Play();
        }

        // Disparar
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
        }
        if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
    
}