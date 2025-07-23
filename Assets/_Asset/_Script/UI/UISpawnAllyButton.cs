using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpawnAllyButton : MonoBehaviour
{
    public string allyName;
    public void SpawnAlly()
    {
        EventDispatcher<string>.Dispatch(Event.SpawnAlly.ToString(), allyName);
        transform.parent.gameObject.SetActive(false);
    }    
}
