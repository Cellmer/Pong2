using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timeTOEnd;
    private bool started;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (timeTOEnd > 0)
            {
                timeTOEnd -= Time.deltaTime;
            }
            else
            {
                timeTOEnd = 0;
                started = false;
                gameManager.EndGame();
            }

            DisplayTime();
        }
    }

    public void SetTimer(float seconds)
    {
        started = true;
        timeTOEnd = seconds;
    }

    public void DisplayTime()
    {
        if(timeTOEnd < 0)
        {
            timeTOEnd = 0;
        }
        else
        {
            int minutes = Mathf.FloorToInt(timeTOEnd / 60);
            int seconds = Mathf.FloorToInt(timeTOEnd % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
