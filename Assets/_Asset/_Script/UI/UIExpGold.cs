using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIExpGold : MonoBehaviour
{
    public TextMeshProUGUI expText;
    public TextMeshProUGUI goldText;
    private void OnEnable()
    {
        EventDispatcher<int>.AddListener(Event.GainGold.ToString(), AddGold);
        EventDispatcher<float>.AddListener(Event.GainExp.ToString(), AddExp);
    }
    private void OnDisable()
    {
        EventDispatcher<int>.RemoveListener(Event.GainGold.ToString(), AddGold);
        EventDispatcher<float>.RemoveListener(Event.GainExp.ToString(), AddExp);
    }
    private void AddGold(int value)
    {
        GameManager.Instance.currentGold += value;
        goldText.text = $"Gold: {GameManager.Instance.currentGold}";
    }   
    private void AddExp(float value)
    {
        GameManager.Instance.currentExp += value;
        expText.text = $"Exp: {GameManager.Instance.currentExp}";
    }    
}
