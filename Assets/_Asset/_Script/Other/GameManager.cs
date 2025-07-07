using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject cardMenu;
    public bool timeRunning;
    private void Awake()
    {
        GameStartSetup();
    }
    private void GameStartSetup()
    {
        GameManager.Instance.timeRunning = false;
        cardMenu.SetActive(true);
    }    
}
