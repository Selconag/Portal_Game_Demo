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
    private string Game_Path;
    //Json string for writing
    private string Gjson;
    //Total path
    string Gpath;
    public Game game;

    public void Start()
    {
        Game_Path = Application.persistentDataPath;
        Gpath = Game_Path + "/Game.json";
        game = GetLocalUserData();     
    }

    private Game GetLocalUserData()
    {
        //check if file is available
        //Game datas
        if (File.Exists(Gpath))
        {
            Gjson = System.IO.File.ReadAllText(Gpath);
            if (Gjson != "")
            return JsonUtility.FromJson<Game>(Gjson);
            else
                return JsonUtility.FromJson<Game>(Gjson);
        }
        else
        {
            //Create New Game Save
            Game game = new Game();
            FileStream x = File.Create(Gpath);
            x.Close();
            Gjson = JsonUtility.ToJson(game) ?? "";
            System.IO.File.WriteAllText(Gpath, Gjson);
            return game;
        }
    }
    public void BuildGameSave()
    {
        Gjson = JsonUtility.ToJson(game);
        File.WriteAllText(Gpath, Gjson);
    }
    public int GetGameSave_Level()
    {
        Gjson = System.IO.File.ReadAllText(Gpath);
        game = JsonUtility.FromJson<Game>(Gjson);
        return game.level;
    }


}
