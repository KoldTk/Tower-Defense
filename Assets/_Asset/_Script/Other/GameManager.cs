using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject cardMenu;
    private void Awake()
    {
        GameStartSetup();
    }
    private void GameStartSetup()
    {
        cardMenu.SetActive(true);
    }    
}
