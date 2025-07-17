using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    [SerializeField] private float timer;
    private TextMeshProUGUI timerNum;
    void Start()
    {
        timer = Mathf.Clamp(timer, 0f, 999);
        timerNum = GetComponent<TextMeshProUGUI>();
        GameCountdown();
    }
    private void Update()
    {
        GameCountdown();
    }
    private void GameCountdown()
    {
        timer -= Time.deltaTime;
        TimeSpan timeInMinute = TimeSpan.FromSeconds(timer);
        string timeFormatted = string.Format("{0:00}:{1:00}", timeInMinute.Minutes, timeInMinute.Seconds);
        timerNum.text = timeFormatted;
        if (timer <= 0)
        {
            timer = 10;
            EventDispatcher<bool>.Dispatch(Event.SpawnEnemy.ToString(), true);
        }    
    }  
}
