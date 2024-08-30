using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic_Script : MonoBehaviour
{
    public int playerScore;

    public bool gameIsOver=false;
    public Text scoreText;

    public Text highScore;
    public GameObject gameOverScreen;

     public GameObject HelpScreen;

    [ContextMenu("Increase Score")]


    void Start(){
        highScore.text =   PlayerPrefs.GetInt("HighScore", 0).ToString();
        
    }


    void Update(){

        if(Input.GetKeyDown(KeyCode.Space)&&gameIsOver){
            restartGame();
        }
    }
    public void addScore(int scoreToadd){
        playerScore = playerScore + scoreToadd;
        scoreText.text = playerScore.ToString();

        if(playerScore>PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore.text = playerScore.ToString();
        }



    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void resetHighScore(){
        PlayerPrefs.DeleteKey("HighScore");
         highScore.text =   0.ToString();
    }

    public void gameOver(){
        gameIsOver=true;
        gameOverScreen.SetActive(true);
       
    }

    public void help(){
        HelpScreen.SetActive(true);
    }

    public void ExitHelp(){
        HelpScreen.SetActive(false);
    }

    public void QuitGame(){
        SceneManager.LoadScene(0);
    }







}
