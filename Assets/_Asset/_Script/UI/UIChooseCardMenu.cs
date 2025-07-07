using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChooseCardMenu : MonoBehaviour
{
    private BuffCardDatabase card;
    private void OnEnable()
    {
        Time.timeScale = 0;
        ShowCardInfo();
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void ShowCardInfo()
    {

    }    
}
