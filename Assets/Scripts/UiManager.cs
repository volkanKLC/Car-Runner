using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    #region SINGLETON
    public static UiManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
    }
    #endregion


    [Header("CANVAS")]
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject isStrartPanel;
    public GameObject pausePanel;

    [Space(10)]

    [Header("VARIABLES")]
    public int Score = 0;
    public Text scoreTxt;
    public bool isStart;

    void Start()
    {
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        isStrartPanel.SetActive(false);
    }
    public void SetScore(int _score)
    {
        Score += _score;
        scoreTxt.text = "SCORE: " + Score;
    }
    public void StrartBtn()
    {
        Time.timeScale = 1;
        isStrartPanel.SetActive(true);
        startPanel.SetActive(false);
        isStart = true;
    }
    public void GameOverBtn()
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

    public void PauseBtn()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }











}
