using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject titleScreen;
    private GameObject difficultiesScreen;
    private GameObject ballSpeedScreen;

    public GameObject player1Paddle;
    public GameObject player2Paddle;
    public GameObject computerPaddle;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        // initialize menu
        titleScreen = GameObject.Find("Title Screen");
        difficultiesScreen = GameObject.Find("Difficulties Screen");
        ballSpeedScreen = GameObject.Find("Ball Speed Screen");
        titleScreen.SetActive(true);
        difficultiesScreen.SetActive(false);
        ballSpeedScreen.SetActive(false);
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
        if(singleplayer)
        {
            difficultiesScreen.SetActive(false);
            Instantiate(player1Paddle);
            Instantiate(player2Paddle);
            Instantiate(ball);
        }
        else
        {
            ballSpeedScreen.SetActive(false);
        }
    }
}
