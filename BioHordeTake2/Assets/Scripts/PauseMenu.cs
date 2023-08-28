using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    private Canvas pauseScreen;
    private string gameInformation;
    public PlayerAbilities playerController;
    private string currentTime;
    private string currentScore;
    public TextMeshProUGUI gameInfoText;
    public AudioSource Alarm1;
    public AudioSource Alarm2;
    public AudioSource Screams;
    private string pauseMessage = "\n \nThis is a short demo created by Michael-John Kenny";
    private PlayerAbilities ap;
    private bool pThisFrame;
    private bool audioWasPlaying = false;
    public GameObject panelOptions;
    public GameObject panelPauseDefault;

    private void Start()
    {
        GameObject pa = GameObject.FindWithTag("PlayerController");
        ap = playerController.GetComponent<PlayerAbilities>();
        currentTime = ap.timeText;
        currentScore = ap.scoreText;
        pauseScreen = this.GetComponent<Canvas>();
        pauseScreen.enabled = false;
        gameInformation = "Current Playtime: error" + "\nCurrent Score: error" +  "\nCurrent Map: Terminal \n"+ pauseMessage;
    }

    private void Update()
    {
        pThisFrame = false;
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            pThisFrame = true;
            pauseGame();
        }
        if (isPaused && !pThisFrame && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            resumeGame();
        }
    }

    public void pauseGame()
    {
        currentTime = ap.timeText;
        currentScore = ap.scoreText;

        gameInformation =
        "Current Playtime: " +
        currentTime +
        "\nCurrent Score: " +
        currentScore +
        "\nCurrent Map: Terminal \n " + 
        pauseMessage;

        gameInfoText.text = gameInformation;
        isPaused = true;
        pauseScreen.enabled = true;
        Time.timeScale = 0f;
        audioWasPlaying = Alarm1.isPlaying;
        if (audioWasPlaying)
        {
            Alarm1.Pause();
            Alarm2.Pause();
            Screams.Pause();
        }
    }

    public void resumeGame()
    {
        isPaused = false;
        pauseScreen.enabled = false;
        Time.timeScale = 1.0f;
        if (audioWasPlaying)
        {
            Alarm1.Play();
            Alarm2.Play();
            Screams.Play();
        }
        
    }

    public void restartGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void optionsGame()
    {
        panelPauseDefault.SetActive(false);
        panelOptions.SetActive(true);
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
