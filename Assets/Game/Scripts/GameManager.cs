using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject notebook;
    public GameObject[] tips;
    public static GameManager gm;
    public int score = 0;
    public Text scoreText;
    public Transform SpawnPoint;
    public bool cursed = false;
    public RoomObserver anubisRoom;
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
        PlayerController.pc.transform.position = SpawnPoint.position;
    }
    public void AddScore(int scoreValue) // pontuação definida pelo collector(script)
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
    public void ShowNotebook()
    {
        notebook.SetActive(true);
    }
    public void HideNotebook()
    {
        notebook.SetActive(false);
    }
    public void PickTip(int tip)
    {
        tips[tip].SetActive(true);
    }
}
