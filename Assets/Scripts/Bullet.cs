using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float hitPower;
    public Transform player;
    float Timer = .2f;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
        if (player.CompareTag("Player1"))
            rb.AddForce(player.right * speed);
        
        if (player.CompareTag("Player2"))
            rb.AddForce(player.right * speed * -1f);
           
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
            Destroy(gameObject);
    }
}
