using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
//Used for data writing and reading
public class DataService : MonoBehaviour
{
    public class Game //LOCAL
    {
        public int level = 0;
        public int portal_amount = 0;
    }
    //Application persistent data path save store location
    private string m_Game_Path;
    //Json string for writing
    private string m_Gjson;
    //Total path
    string m_Gpath;
    public Game Game_;

    public void Start()
    {
        m_Game_Path = Application.persistentDataPath;
        m_Gpath = m_Game_Path + "/Game.json";
        Game_ = getLocalUserData();     
    }

    private Game getLocalUserData()
    {
        //check if file is available
        //Game datas
        if (File.Exists(m_Gpath))
        {
            m_Gjson = System.IO.File.ReadAllText(m_Gpath);
            if (m_Gjson != "")
            {
                return JsonUtility.FromJson<Game>(m_Gjson);
            }
            else
                return JsonUtility.FromJson<Game>(m_Gjson);
        }
        else
        {
            //Create New Game Save
            Game_ = new Game();
            FileStream x = File.Create(m_Gpath);
            x.Close();
            m_Gjson = JsonUtility.ToJson(Game_) ?? "";
            System.IO.File.WriteAllText(m_Gpath, m_Gjson);
            return Game_;
        }
    }
    public void BuildGameSave()
    {
        m_Gjson = JsonUtility.ToJson(Game_);
        File.WriteAllText(m_Gpath, m_Gjson);
    }
    public int GetGameSave_Level()
    {
        m_Gjson = System.IO.File.ReadAllText(m_Gpath);
        Game_ = JsonUtility.FromJson<Game>(m_Gjson);
        return Game_.level;
    }


}
