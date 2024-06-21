using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore=0;
    public int coins = 0;
    public Text scoreText;
    public Text maxscore;
    public Text coin;



    // public Button pauseBirdBtn;
    public GameObject gameOverScreen;


    int mx = 0;

    private void Start()
    {
        maxscore.text = PlayerPrefs.GetInt("Score", 0).ToString();

    }

    [ContextMenu("Increase coin")]
    public void addCoin(int coinToAdd)
    {
        coins += coinToAdd;
        coin.text=coins.ToString();
    }

    [ContextMenu("Increase score")]
    public void addScore(int scoreToAdd)
    {
        Debug.Log("incresedscore");
        playerScore= playerScore+ scoreToAdd;
       

        scoreText.text= playerScore.ToString();

        //maxscore.text= PlayerPrefs.GetInt("Score",0).ToString();

        if (playerScore > PlayerPrefs.GetInt("Score",0))
        {
            mx = playerScore;
            PlayerPrefs.SetInt("Score", playerScore);
            maxscore.text = mx.ToString();
        }
    }



    public void RestartGame()
    {
       // Debug.Log("presed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
