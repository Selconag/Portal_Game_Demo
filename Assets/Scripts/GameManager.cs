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
    [SerializeField] private GameObject InGameMenuPanel;
    

    //Holds info text
    public Text InfoText;
    public GameObject ButtonNext;
    public GameObject ButtonRetry;

    public Text LevelText;
    public Text PortalText;
    //S is for Save
    private DataService S;

    //Global level variable for storing and using active level info
    private int level;
    private int portal_amount;

    //Level selection happens here
    public void Select_Level(int select)
    {
        level = select;
        MenuPanel.SetActive(false);
        Draw_Level(false);
    }

    private void Start()
    {
        S = GameObject.Find("DataService").GetComponent<DataService>();
        
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
        //Get the local save file
        int level = S.GetGameSave_Level();
        //If there is a local save
        if(level > 0)
        {
            Draw_Level(false);
            MainMenuPanel.SetActive(false);
            MenuPanel.SetActive(false);
            LevelSelectPanel.SetActive(false);
        }
        //Else (if there is not a local save)act as start button
        else
        {
            Start_Button();
        }
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
        Save_System();
        Application.Quit();
    }

    public void Back_Button()
    {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }
    public void InGameMenu_Button()
    {
        Time.timeScale = 0;
        InGameMenuPanel.SetActive(true);
    }
    public void ResumeGame_Button()
    {
        Time.timeScale = 1;
        InGameMenuPanel.SetActive(false);
    }
    public void ReturntoMainMenu_Button()
    {
        Time.timeScale = 1;
        Save_System();
        Game_Resolution(false);
        MainMenuPanel.SetActive(true);
        MenuPanel.SetActive(true);
        InGameMenuPanel.SetActive(false);
    }

    private void Save_System()
    {
        S.game.level = level;
        S.game.portal_amount = portal_amount;
        S.BuildGameSave();
    }

    #endregion


    #region InGame
    //The Prefab
    [SerializeField] private GameObject Ball;
    //Prefabs Initial location
    [SerializeField] private Transform Ball_T;
    public GameObject GameGround_1;
    public GameObject GameGround_2;
    public GameObject GameGround_3;
    //Instantiated object
    private GameObject Player;

    //Takes info of resolution and calls Draw level depends on the situation
    public void Game_Resolution(bool Win)
    {
        switch (level)
        {
            case 1:
                GameGround_1.transform.rotation = Quaternion.Euler(0, 0, 0); 
                GameGround_1.SetActive(false);
                break;
            case 2:
                GameGround_2.transform.rotation = Quaternion.Euler(0, 0, 0);
                GameGround_2.SetActive(false);
                break;
            case 3:
                GameGround_3.transform.rotation = Quaternion.Euler(0, 0, 0);
                GameGround_3.SetActive(false);  
                break;
        }

        InfoPanel.SetActive(true);
        //Tell User he/she win this level
        if (Win)
        {
            InfoText.text = "You Win!";
            ButtonNext.SetActive(true);
        }
        //Tell User he/she lose this level so must retry or exit
        else
        {
            InfoText.text = "You Lose";
            ButtonRetry.SetActive(true);
            if (Player.activeInHierarchy)
            {
                Destroy(Player);
            }
        }
            
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
            case 0:
                GameGround_1.SetActive(true);
                GameGround_1.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
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
        //Instantiate a ball
        Player = Instantiate(Ball,Ball_T);
    }
    #endregion
}
