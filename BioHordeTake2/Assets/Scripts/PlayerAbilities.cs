using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilities : MonoBehaviour 
{
    public GameObject fastForwardEffect;
    private float currentTime = 0f;
    private int playerScore = 0;

    public string timeText = "";
    public string scoreText = ""; 

    public Text currentTimeText;
    public Text playerScoreText;

    private void Start()
    {
        fastForwardEffect.SetActive(false);
        currentTime = 0f;
        timeText = "0";
        scoreText = "0";
    }

    public void updatePlayerScore(int amount)
    {
        playerScore += amount;
        scoreText = playerScore.ToString();
        playerScoreText.text = scoreText;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        timeText = currentTime.ToString("n2");
        currentTimeText.text = timeText;
        
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            Time.timeScale = 4f;
            fastForwardEffect.SetActive(true);
        } else
        //Change this but this is the problem
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            fastForwardEffect.SetActive(false);
        }
    }
}