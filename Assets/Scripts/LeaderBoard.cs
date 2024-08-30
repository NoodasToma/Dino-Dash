using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{

    public List<TextMeshProUGUI> names;

    public List<TextMeshProUGUI> scores;

    private String leaderboardKey = "980324f10e2f03fc0fd6a38a70f88123919a6aed35a4aea86211ad58b68db9c4";

    // Start is called before the first frame update
    void Start()
    {
        GetLeaderBoard();
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
    }


    public void setEntry(String name , int score){

        
        if(name.Length>25) name = name.Substring(0,25);

        LeaderboardCreator.UploadNewEntry(leaderboardKey,name,score,((_) => {
            GetLeaderBoard();
        }));
    }
}
