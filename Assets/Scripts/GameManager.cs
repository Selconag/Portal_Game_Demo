using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Basic gamemanager for the sake of simplicity I didn't split menu and ingame interactions
public class GameManager : MonoBehaviour
{
    #region Menu
    //holds InfoPanel
    [SerializeField] protected GameObject InfoPanel;
    [SerializeField] protected GameObject MenuPanel;
    [SerializeField] protected GameObject MainMenuPanel;
    [SerializeField] protected GameObject LevelSelectPanel;
    [SerializeField] protected GameObject InGameMenuPanel;
    

    //Holds info text
    public Text InfoText;
    public GameObject ButtonNext;
    public GameObject ButtonRetry;

    public Text LevelText;
    public Text PortalText;
    //S is for Save
    private DataService m_S;

    //Global level variable for storing and using active level info
    private int m_Level;
    private int m_Portal_Amount;

    //Level selection happens here
    public void Select_Level(int select)
    {
        m_Level = select;
        MenuPanel.SetActive(false);
        Draw_Level(false);
    }

    private void Start()
    {
        m_S = GameObject.Find("DataService").GetComponent<DataService>();

        //Read Application.persistentDataPath for save game
        if (GameObject.Find("GameManager").GetComponent<GameManager>().isActiveAndEnabled)
        {
            GameManager m_G = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        else
        {
            GameManager m_G = new GameManager();
        }
        m_Level = m_S.Game_.level;
        m_Portal_Amount = m_S.Game_.portal_amount;

    }

    //Continue from where you left
    public void Continue_Button()
    {
        //Get the local save file
        int level = m_S.GetGameSave_Level();
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
        m_S.Game_.level = m_Level;
        m_S.Game_.portal_amount = m_Portal_Amount;
        m_S.BuildGameSave();
    }

    #endregion


    #region InGame
    //The Prefab
    public GameObject Ball;
    //Prefabs Initial location
    public Transform Ball_T;
    public GameObject GameGround_1;
    public GameObject GameGround_2;
    public GameObject GameGround_3;
    //Instantiated object
    private GameObject m_Player;

    //Takes info of resolution and calls Draw level depends on the situation
    public void Game_Resolution(bool Win)
    {
        switch (m_Level)
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
        }
            
    }
    //Gets the active level info
    //if there is a save, loads that level

    //Also called from Game_Resolution() method
    //if succes => info panel shows up and after click continue next level loads
    //else failure => retry or return to main menu button shows up
    public void Draw_Level(bool Win)
    {
        if(Win) m_Level++;
        LevelText.text = "Level:" + m_Level;
        PortalText.text = "Portals:" + m_Level;
        ButtonNext.SetActive(false);
        ButtonRetry.SetActive(false);
        InfoPanel.SetActive(false);
        switch (m_Level)
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
        GameObject Player = Instantiate(Ball,Ball_T.position, Ball_T.rotation);
    }
    #endregion
}
