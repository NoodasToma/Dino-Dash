using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Dan.Main;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LeaderBoard : MonoBehaviour
{

    public List<TextMeshProUGUI> names;

    public List<TextMeshProUGUI> scores;

    private String leaderboardKey = "13affdd64aa333fe7b65577c2902dc4fcf968d5ede33bd147746dad4965dd2e2";

    private  String  PlayerName;

    public TextMeshProUGUI inputField;

    
    // Start is called before the first frame update
    void Start()
    {
     
        GetLeaderBoard();
        
    }



    public void SetName(String InputName){
        PlayerName=InputName;
        PlayerPrefs.SetString("Name",PlayerName);
        setEntry(PlayerPrefs.GetString("Name","Empty"),PlayerPrefs.GetInt("HighScore",0));
        
    }

    // Update is called once per frame
   

    public void GetLeaderBoard(){
        LeaderboardCreator.GetLeaderboard(leaderboardKey,((msg) => {
            int loopLenght = (msg.Length<names.Count) ? msg.Length : names.Count;
            for(int i =0 ; i<loopLenght ; i++){
                names[i].text=msg[i].Username;
                scores[i].text=msg[i].Score.ToString();
            }
        }));

        inputField.text = PlayerPrefs.GetString("Name","EnterName");
    }


    public void setEntry(String name , int score){

        
        if(name.Length>15) name = name.Substring(0,15);

        LeaderboardCreator.UploadNewEntry(leaderboardKey,name,score,((_) => {
            GetLeaderBoard();
        }));
    }
}
