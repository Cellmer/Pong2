using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject difficultiesScreen;
    public GameObject ballSpeedScreen;
    public TextMeshProUGUI leftPlayerScoreText;
    public TextMeshProUGUI rightPlayerScoreText;

    public GameObject player1PaddlePrefab;
    public GameObject player2PaddlePrefab;
    public GameObject computerPaddlePrefab;
    public GameObject ballPrefab;
    public GameObject slowBallPrefab;
    public GameObject fastBallPrefab;
    public GameObject superFastBallPrefab;

    private int difficulty;
    private bool singleplayer;
    private int leftPlayerScore;
    private int rightPlayerScore;

    // Start is called before the first frame update
    void Start()
    {
        // initialize menu
        titleScreen.SetActive(true);
        difficultiesScreen.SetActive(false);
        ballSpeedScreen.SetActive(false);
        leftPlayerScoreText.text = "";
        rightPlayerScoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDifficultiesScreen()
    {
        titleScreen.SetActive(false);
        difficultiesScreen.SetActive(true);
    }

    public void ShowBallSpeedScreen()
    {
        titleScreen.SetActive(false);
        ballSpeedScreen.SetActive(true);
    }

    public void StartGame(bool singleplayer, int difficulty)
    {
        this.difficulty = difficulty;
        this.singleplayer = singleplayer;

        leftPlayerScore = 0;
        rightPlayerScore = 0;
        leftPlayerScoreText.text = leftPlayerScore.ToString(); 
        rightPlayerScoreText.text = rightPlayerScore.ToString(); 

        if(singleplayer)
        {
            difficultiesScreen.SetActive(false);
        }
        else
        {
            ballSpeedScreen.SetActive(false);
            Instantiate(player1PaddlePrefab);
            Instantiate(player2PaddlePrefab);
            ThrowBall();
        }
    }

    public void ThrowBall()
    {
        if (difficulty == 1)
            Instantiate(slowBallPrefab);
        else if (difficulty == 2)
            Instantiate(ballPrefab);
        else
            Instantiate(fastBallPrefab);
    }

    public void UpdateLeftPlayerScore()
    {
        leftPlayerScore += 1;
        leftPlayerScoreText.text = leftPlayerScore.ToString();
    }

    public void UpdateRightPlayerScore()
    {
        rightPlayerScore += 1;
        rightPlayerScoreText.text = rightPlayerScore.ToString();
    }
}
