using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject background;
    public GameObject arrow1;
    public GameObject arrow2;
    
    private Text rightTxt;
    private Text leftTxt;
    private Text infoTxt;
    private Text title;

    public bool gameIsOver = false;
    
    void Start()
    {
        rightTxt = GameObject.Find("Right2").GetComponent<Text>();
        leftTxt = GameObject.Find("Left1").GetComponent<Text>();
        infoTxt = GameObject.Find("Talk").GetComponent<Text>();
        title = GameObject.Find("Title").GetComponent<Text>();
        leftTxt.text = " ";
        rightTxt.text = " ";
        infoTxt.text = " ";
        
        background.SetActive(false);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            title.enabled = false;
            background.SetActive(true);
            arrow1.SetActive(true);
            arrow2.SetActive(true);
        }

        if (gameIsOver)
        {
            GameOver();
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    
    void GameOver()
    {
        if (player1.GetComponent<Player>().playerDead)
        {
            leftTxt.text = "DEAD";
            rightTxt.text = "WINNER";
            infoTxt.text = "Press R For Rematch";
        }

        if (player2.GetComponent<Player>().playerDead)
        {
            leftTxt.text = "WINNER";
            rightTxt.text = "DEAD";
            infoTxt.text = "Press R For Rematch";
        }
    }
}
