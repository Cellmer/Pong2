using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject titleScreen;
    private GameObject difficultiesScreen;
    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("Title Screen");
        difficultiesScreen = GameObject.Find("Difficulties Screen");
        titleScreen.SetActive(true);
        difficultiesScreen.SetActive(false);
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
}
