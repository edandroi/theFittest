using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMe : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public int health1;
    public int health2;
    
    void Start()
    {
        
    }

    void Update()
    {
        health1 = player1.GetComponent<Player>().health;
        health2 = player2.GetComponent<Player>().health;
        
//        Debug.Log("Player1 health is "+health1);
//        Debug.Log("Player2 health is "+health2);
        
        Debug.Log("P1 is shot is "+ player1.GetComponent<Player>().isShot);
    }
}
