using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
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

    public GameObject cam1;
    public GameObject cam2;

    public bool gameIsOver = false;
    
    void Start()
    {
        // set both cams inactive until players are in
        cam1 = GameObject.Find("Cam1");
        cam2 = GameObject.Find("Cam2");
        cam1.SetActive(false);
        cam2.SetActive(false);
        
        
        rightTxt = GameObject.Find("Right2").GetComponent<Text>();
        leftTxt = GameObject.Find("Left1").GetComponent<Text>();
        infoTxt = GameObject.Find("Talk").GetComponent<Text>();
        title = GameObject.Find("Title").GetComponent<Text>();
        leftTxt.text = " ";
        rightTxt.text = " ";
        infoTxt.text = " ";
        
        /*
        background.SetActive(false);
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        */
    }

    void Update()
    {
        /*
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
            */
    }
    
    void StartGame()
    {
        
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

    public void CreateArrow(GameObject target, int offset, int arrowNum)
    {
        Debug.Log("making arrow now");
        var newArrow = new GameObject();
        newArrow.name = "Arrow" + arrowNum;
        newArrow.AddComponent<Arrow>();
        newArrow.GetComponent<Arrow>().targetObj = target.transform;
        newArrow.AddComponent<SpriteRenderer>();
        newArrow.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Arrow");
        newArrow.GetComponent<SpriteRenderer>().color = Color.black;
        newArrow.GetComponent<SpriteRenderer>().sortingOrder = 2;

        var thisCam = new GameObject();
        switch (arrowNum - 1)
        {
            case 0: // if cam is 1
                thisCam = cam1;
                break;
            case 1: // if cam is 2
                thisCam = cam2;
                break;
        }
        
        Vector3 coordinates = new Vector3(Screen.width + offset, Screen.height/2, 0);
        newArrow.transform.position = new Vector3(thisCam.GetComponent<Camera>().ScreenToWorldPoint(coordinates).x, thisCam.GetComponent<Camera>().ScreenToWorldPoint(coordinates).y, 0 );

        newArrow.AddComponent<CamFollow>();
        newArrow.GetComponent<CamFollow>().player = target.transform;
        newArrow.GetComponent<CamFollow>().distanceFromPlayer = 6;
        newArrow.GetComponent<CamFollow>().lerpSpeed = .7f;
    }

    public void SetCamActive(int i, GameObject player)
    {
        i -= 1;
        switch (i) //cam1
        {
            case 0:
                cam1.GetComponent<CamFollow>().player = player.transform;
                cam1.SetActive(true);
                break;
            case 1:
                cam2.GetComponent<CamFollow>().player = player.transform;
                cam2.SetActive(true);
                break;
        }
        
    }
}
