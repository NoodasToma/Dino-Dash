using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
   public GameObject HelpScreen;
   public void StartGame(){
    SceneManager.LoadScene(1);
   }


   public void help(){
        HelpScreen.SetActive(true);
    }

    public void ExitHelp(){
        HelpScreen.SetActive(false);
    }


   public void QuitGame(){
      Application.Quit();
   }
   
}
