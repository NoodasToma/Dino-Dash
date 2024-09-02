using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Logic_Script : MonoBehaviour
{
    public int playerScore;

    private bool screenCalled = false;
    private bool recordBreak = false;
    public bool gameIsOver=false;
    public Text scoreText;

    public Text highScore;
    public GameObject gameOverScreen;

    public GameObject HelpScreen;

    public GameObject LeaderBoard; 

    public LeaderBoard lb;

   

    [ContextMenu("Increase Score")]


    void Start(){
        highScore.text =   PlayerPrefs.GetInt("HighScore", 0).ToString();

        lb = GameObject.FindGameObjectWithTag("LeaderBoard").GetComponent<LeaderBoard>();
        
    }


    void Update(){

        if(Input.GetKeyDown(KeyCode.Space)&&gameIsOver&&gameOverScreen.activeSelf){
            restartGame();
        }
    }
    public void addScore(int scoreToadd){
        playerScore = playerScore + scoreToadd;
        scoreText.text = playerScore.ToString();

        if(playerScore>PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore.text = playerScore.ToString();
            recordBreak = true;
        }



    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void openLeaderBoard(){
        LeaderBoard.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void gameOver(){
        gameIsOver=true;
        if (screenCalled == false)
        {
            gameOverScreen.SetActive(true);
            screenCalled = true;
            if(recordBreak){
             lb.setEntry(PlayerPrefs.GetString("Name","Empty"),PlayerPrefs.GetInt("HighScore",0));
            }
           
        }
        
       
    }

    public void help(){
        HelpScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void ExitHelp(){
        HelpScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        LeaderBoard.SetActive(false);
    }

    public void QuitGame(){
        SceneManager.LoadScene(0);
    }







}
