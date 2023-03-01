using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public int difficulty;
    public bool singleplayer;

    private Button button;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(StartProperGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartProperGame()
    {
        gameManager.StartGame(singleplayer, difficulty);
    }
}
