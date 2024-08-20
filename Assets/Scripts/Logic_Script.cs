using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic_Script : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public Text highScore;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]


    void Start(){
        highScore.text =   PlayerPrefs.GetInt("HighScore", 0).ToString();
        
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
        gameOverScreen.SetActive(true);
       
    }





}
