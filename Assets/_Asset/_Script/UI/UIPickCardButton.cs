using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPickCardButton : MonoBehaviour
{
    public GameObject cardMenu;

    public void PickCard()
    {
        ApplyEffect();
        TurnOffCardMenu();
    }
    private void ApplyEffect()
    {

    }
    private void TurnOffCardMenu()
    {
        cardMenu.SetActive(false);
        EventDispatcher<bool>.Dispatch(Event.UnPause.ToString(), true);
    }    
}
