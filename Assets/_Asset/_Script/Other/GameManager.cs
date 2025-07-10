using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject cardMenu;
    public bool timeIsRunning;
    public bool enemyIsSpawning;
    private void Awake()
    {
        GameStartSetup();
    }
    private void GameStartSetup()
    {
        Time.timeScale = 0;
        timeIsRunning = false;
        cardMenu.SetActive(true);
    }    
}
