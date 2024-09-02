using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
   public GameObject HelpScreen;

   public GameObject Buttons;

   public GameObject LeaderBoard;


   

   void Start(){

   }
   public void StartGame(){
    SceneManager.LoadScene(1);
   }


   public void help(){
        HelpScreen.SetActive(true);
        Buttons.SetActive(false);
    }

    public void ExitHelp(){
        HelpScreen.SetActive(false);
        Buttons.SetActive(true);
        LeaderBoard.SetActive(false);
    }


   public void QuitGame(){
      Application.Quit();
   }

   public void EnterLeaderBoard(){
      Buttons.SetActive(false);
      LeaderBoard.SetActive(true);

   }

   
   
}
