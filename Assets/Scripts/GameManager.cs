using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // menu elements
    [SerializeField]
    private GameObject titleScreen;

    [SerializeField]
    private GameObject difficultiesScreen;

    [SerializeField]
    private GameObject ballSpeedScreen;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private TextMeshProUGUI leftPlayerScoreText;

    [SerializeField]
    private TextMeshProUGUI rightPlayerScoreText;

    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField]
    private TextMeshProUGUI beforeThrowTimer;

    // prefabs
    [SerializeField]
    private GameObject player1PaddlePrefab;

    [SerializeField]
    private GameObject player2PaddlePrefab;

    [SerializeField]
    private GameObject computerEasyPaddlePrefab;

    [SerializeField]
    private GameObject computerMediumPaddlePrefab;

    [SerializeField]
    private GameObject computerHardPaddlePrefab;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject slowBallPrefab;

    [SerializeField]
    private GameObject fastBallPrefab;

    [SerializeField]
    private List<GameObject> powerups;

    private int difficulty;
    private bool singleplayer;
    private int leftPlayerScore;
    private int rightPlayerScore;
    private bool isGameActive;
    private float gameDuration;

    // Start is called before the first frame update
    void Start()
    {
        // initialize menu
        titleScreen.SetActive(true);
        difficultiesScreen.SetActive(false);
        ballSpeedScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        leftPlayerScoreText.text = "";
        rightPlayerScoreText.text = "";
        beforeThrowTimer.text = "";

        isGameActive = false;
        gameDuration = 100.0f;
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

        isGameActive = true;
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        leftPlayerScoreText.text = leftPlayerScore.ToString(); 
        rightPlayerScoreText.text = rightPlayerScore.ToString();
        GameObject.Find("Timer").GetComponent<Timer>().SetTimer(gameDuration);


        if(singleplayer)
        {
            difficultiesScreen.SetActive(false);
            Instantiate(player1PaddlePrefab);
            if (difficulty == 1)
                Instantiate(computerEasyPaddlePrefab);
            else if (difficulty == 2)
                Instantiate(computerMediumPaddlePrefab);
            else
                Instantiate(computerHardPaddlePrefab);
        }
        else
        {
            ballSpeedScreen.SetActive(false);
            Instantiate(player1PaddlePrefab);
            Instantiate(player2PaddlePrefab);
        }

        StartCoroutine(ThrowBall(null));
        StartCoroutine(SpawnPowerups());
    }

    public IEnumerator ThrowBall(GameObject oldBall)
    {
        if (isGameActive)
        {
            beforeThrowTimer.text = "3";
            yield return new WaitForSeconds(1.0f);
            beforeThrowTimer.text = "2";
            yield return new WaitForSeconds(1.0f);
            beforeThrowTimer.text = "1";
            yield return new WaitForSeconds(1.0f);
            beforeThrowTimer.text = "";
            if (difficulty == 1)
                Instantiate(slowBallPrefab);
            else if (difficulty == 2)
                Instantiate(ballPrefab);
            else
                Instantiate(fastBallPrefab);
        }

        if (oldBall != null)
            Destroy(oldBall);
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

    public void EndGame()
    {
        gameOverScreen.SetActive(true);
        beforeThrowTimer.text = "";
        isGameActive = false;
        if (leftPlayerScore == rightPlayerScore)
        {
            gameOverText.text = "DRAW!";
        }
        else
        {
            if (singleplayer)
            {
                if (leftPlayerScore > rightPlayerScore)
                {
                    gameOverText.text = "YOU LOST!";
                }
                else
                {
                    gameOverText.text = "YOU WON!";
                }
            }
            else
            {
                if (leftPlayerScore > rightPlayerScore)
                {
                    gameOverText.text = "LEFT PLAYER WON!";
                }
                else
                {
                    gameOverText.text = "RIGHT PLAYER WON!";
                }
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnPowerups()
    {
        float spawnRate;
        while(isGameActive)
        {
            spawnRate = Random.Range(2.0f, 8.0f);
            yield return new WaitForSeconds(spawnRate);
            Instantiate(powerups[Random.Range(0, powerups.Count)]);
        }
    }
}
