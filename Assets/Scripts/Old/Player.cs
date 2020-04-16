using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public KeyCode right;
    public KeyCode left;
    public KeyCode forward;
//    public KeyCode rotating;
    public KeyCode shoot;

    public GameManager m_GameManager;
    public GameObject bulletObj;
    public AudioClip shootSFX;
    public AudioClip shot;
    
    public AudioSource m_AudioSourceShoot;
    public AudioSource m_AudioSourceShot;
    
    public float jumpSpeed;
    public float torque;
    public float maxVelocity = 20f;
    public int health = 20;

    public bool playerDead = false;
    public bool isShot;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SpawnPoint();
//        Debug.Log(spawnPoint);
    }

    private void FixedUpdate()
    {
        if (!playerDead)
            PlayerMovement();
    }

    private void Update()
    {
        if (!playerDead)
           Shoot();
        
        if (health <= 0)
            GameOver();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(right))
        {
            rb.AddTorque(-torque );
        }
        
        if (Input.GetKey(left))
        {
            rb.AddTorque(torque );
        }
        
        
        if (Input.GetKey(forward))
        {
            if (gameObject.CompareTag("Player1"))
                rb.AddForce(transform.right * jumpSpeed);
        
            if (gameObject.CompareTag("Player2"))
                rb.AddForce(transform.right * jumpSpeed * -1f);
                
        } 
        Vector2 v = rb.velocity;
        
        if(v.magnitude > maxVelocity)
         rb.velocity = v.normalized * maxVelocity;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(shoot))
        {
            GameObject bullet = Instantiate(bulletObj, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Bullet>().player = gameObject.transform;

            if (gameObject.CompareTag("Player1"))
                bullet.tag = "Bullet1";
            
            if (gameObject.CompareTag("Player2"))
                bullet.tag = "Bullet2";
            
            m_AudioSourceShoot.PlayOneShot(shootSFX, .7f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.CompareTag("Player1"))
        {
            if (other.gameObject.CompareTag("Bullet2"))
            {
                isShot = true;
                m_AudioSourceShot.PlayOneShot(shot, .05f);
                health--;
            }
        }
        
        if (gameObject.CompareTag("Player2"))
        {
            if (other.gameObject.CompareTag("Bullet1"))
            {
                isShot = true;
                health--;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isShot = false;
    }

    // Player2 sag kamera
    
    void GameOver()
    {
        playerDead = true;
        m_GameManager.gameIsOver = true;
        rb.AddTorque(torque* 2f );
    }

    private float xVal;
    private float yVal;
    private Vector3 spawnPoint;
    
    void SpawnPoint()
    {
        yVal = Random.Range(18f, 85f);
        if (gameObject.CompareTag("Player1"))
        {
            xVal = Random.Range(30f, 75f);    
        }
        
        if (gameObject.CompareTag("Player2"))
        {
            xVal = Random.Range(105f, 150f);
        }
        spawnPoint = new Vector3(xVal, yVal, transform.position.z);
        transform.position = new Vector3(xVal, yVal, transform.position.z);
    }
}
