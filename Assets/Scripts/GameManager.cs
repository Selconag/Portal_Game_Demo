using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    #region Menu
    //holds InfoPanel
    [SerializeField] private GameObject InfoPanel;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject LevelSelectPanel;

    //Holds info text
    public Text InfoText;
    public GameObject ButtonNext;
    public GameObject ButtonRetry;

    public Text LevelText;
    public Text PortalText;

    
    //Global level variable for storing and using active level info
    private int level;

    //Level selection happens here
    public void Select_Level(int select)
    {
        level = select;
        MenuPanel.SetActive(false);
        Draw_Level(false);
    }

    private void Start()
    {
        //Read Application.persistentDataPath for save game
        if (GameObject.Find("GameManager").GetComponent<GameManager>().isActiveAndEnabled)
        {
            GameManager G = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        else
        {
            GameManager G = new GameManager();
        }
    }
    //Continue from where you left
    public void Continue_Button()
    {
        MainMenuPanel.SetActive(false);
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
        //Load the game
    }
    //Start the game from game panel
    public void Start_Button()
    {
        MainMenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
    }
    //Exit from game
    public void Exit_Button()
    {
        Application.Quit();
    }

    public void Back_Button()
    {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }
    #endregion


    #region InGame
    [SerializeField] private GameObject Ball;
    [SerializeField] private Transform Ball_T;
    public GameObject GameGround_1;
    public GameObject GameGround_2;
    public GameObject GameGround_3;


    private void Update()
    {

    }


    //Takes info of resolution and calls Draw level depends on the situation
    public void Game_Resolution(bool Win)
    {
        switch (level)
        {
            case 1:
                GameGround_1.SetActive(false);
                break;
            case 2:
                GameGround_2.SetActive(false);
                break;
            case 3:
                GameGround_3.SetActive(false);
                break;
        }
        InfoPanel.SetActive(true);
        if (Win)
            ButtonNext.SetActive(true);
        else
            ButtonRetry.SetActive(true);
    }
    //Gets the active level info
    //if there is a save, loads that level

    //Also called from Game_Resolution() method
    //if succes => info panel shows up and after click continue next level loads
    //else failure => retry or return to main menu button shows up
    [SerializeField]private void Draw_Level(bool Win)
    {
        if(Win) level++;
        LevelText.text = "Level:" + level;
        PortalText.text = "Portals:" + level;
        ButtonNext.SetActive(false);
        ButtonRetry.SetActive(false);
        InfoPanel.SetActive(false);
        switch (level)
        {
            case 1:
                GameGround_1.SetActive(true);
                GameGround_1.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                GameGround_2.SetActive(true);
                GameGround_2.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 3:
                GameGround_3.SetActive(true);
                GameGround_3.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
        //Not working right now
        //GameObject.Find("GameGround_" + level).SetActive(true);
        //Spawn ball
        GameObject Player = Instantiate(Ball,Ball_T);
    }
    #endregion
}
