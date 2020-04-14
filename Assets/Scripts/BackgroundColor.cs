using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;


public class BackgroundColor : MonoBehaviour
{

    public GameObject m_Player;
    private int m_PlayerHealth;
    private int m_Health;
    private Color32 startColor;
    public Color32 endColor;
    private PostProcessingBehaviour m_PosPro;
    
    void Start()
    {
        m_Health = m_Player.GetComponent<Player>().health;
        startColor = GetComponent<Camera>().backgroundColor;
        m_PosPro = GetComponent<PostProcessingBehaviour>();
    }

    void Update()
    {
        m_PlayerHealth = m_Player.GetComponent<Player>().health;
        if (m_PlayerHealth != m_Health)
        {
            if (GetComponent<Camera>().backgroundColor != endColor)
                GetComponent<Camera>().backgroundColor =
                    Color32.Lerp(GetComponent<Camera>().backgroundColor, endColor, 1/m_PlayerHealth);
        }

        m_Health = m_PlayerHealth;
    }
}
