using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject titleScreen;
    private GameObject difficultiesScreen;
    private GameObject ballSpeedScreen;

    public GameObject player1PaddlePrefab;
    public GameObject player2PaddlePrefab;
    public GameObject computerPaddlePrefab;
    public GameObject ballPrefab;
    public GameObject slowBallPrefab;
    public GameObject fastBallPrefab;
    public GameObject superFastBallPrefab;

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
            Instantiate(player1PaddlePrefab);
            Instantiate(player2PaddlePrefab);
            if (difficulty == 1)
                Instantiate(slowBallPrefab);
            else if (difficulty == 2)
                Instantiate(ballPrefab);
            else
                Instantiate(fastBallPrefab);
        }
        else
        {
            ballSpeedScreen.SetActive(false);
        }
    }
}
