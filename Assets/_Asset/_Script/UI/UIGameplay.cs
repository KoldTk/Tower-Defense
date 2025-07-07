using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    private float timer = 15.5f;
    public TextMeshProUGUI timerNum;
    void Start()
    {
        TimerCountdown();
        EventDispatcher<bool>.AddListener(Event.UnPause.ToString(), TimerStart);
    }
    private void Update()
    {
        if (GameManager.Instance.timeRunning)
        {
            TimerCountdown();
        }    
    }
    private void TimerStart(bool unPause)
    {
        if (unPause)
        {
            GameManager.Instance.timeRunning = true;
        }     
    }
    private void TimerCountdown()
    {
        timer -= Time.deltaTime;
        TimeSpan timeInMinute = TimeSpan.FromSeconds(timer);
        string timeFormatted = string.Format("{0:00}:{1:00}", timeInMinute.Minutes, timeInMinute.Seconds);
        timerNum.text = timeFormatted;
    }    
}
