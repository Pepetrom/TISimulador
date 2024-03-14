using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int score = 0;
    public Text scoreText;
    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int scoreValue) // pontua��o definida pelo collector(script)
    {
        score += scoreValue;
        AttUIScore();
    }
    public void AttUIScore()
    {
        if(scoreText != null)
        {
            scoreText.text = "Coins: " + score.ToString();
        }
    }
}