using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject startMenuUI;
    public GameObject gameLossUI;
    public GameObject gameWonUI;


    public static PauseMenu _instance = null;
    public static PauseMenu Instance
    {
        get { return _instance; }
    }
    void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ReturnToHub()
    {
        //oh golly oh my how will this work
        string playerScore = PlayerPrefs.GetString("PlayerScore");
        //send that??
        //get Player instance and check if a powerup was used? do anything with that or
        //  let it be???
        //public bool greenPowerUpActivated = false;

        //for now I'll just let pressing "YES" on "RETURN TO HUB?" be the same as "NO"
        //  which is to say...resume
        pauseMenuUI.SetActive(false);
        gameLossUI.SetActive(false);
        gameWonUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void GameOver()
    {
       
        gameLossUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void GameRedo()
    {
        gameLossUI.SetActive(false);
        gameWonUI.SetActive(false);

        Player.Instance.RestartGame();
        Shoot.Instance.RestartSooperBooletCount();
        WaveSpawner.Instance.RestartEnemies();

        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void GameWon()
    {
        gameWonUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
