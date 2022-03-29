using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject isStrartPanel;
    public GameObject closePanel;
    public GameObject pausePanel;
    public int Score = 0;
    public Text higtScore;
    public bool isStart;








    public static UI Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

    }

    void Start()
    {
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        isStrartPanel.SetActive(false);
    }
    public void SetScore(int _score) 
    {
        Score += _score;
        higtScore.text = "SCORE: " + _score;
    }

    void Update()
    {
        
    }
   public void StrartBtn()
    {
        Time.timeScale = 1;
        isStrartPanel.SetActive(true);
        startPanel.SetActive(false);
        isStart = true;
    }
    public void GameOverByn() 
    {
        startPanel.SetActive(false);
        gameOverPanel.SetActive(true);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        
    }
    public void SettingBtn() 
    {
        pausePanel.SetActive(true);


    }
    public void CloseBtn(int value) 
    {
        closePanel.SetActive(true);

        if (value==1)
        {
            closePanel.SetActive(false);
        }
        if (value==0)
        {
            Application.Quit();
        }
        if (value==-1)
        {
            closePanel.SetActive(false);
        }


    }

    public void PauseBtn() 
    {
        Time.timeScale = 0;
    }

    public void retyBtn() 
    {
        Time.timeScale = 1;
    }











}
