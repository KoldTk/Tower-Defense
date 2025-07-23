using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public List<Ally> characterList = new List<Ally>();
    private void Start()
    {
        EventDispatcher<string>.AddListener(Event.SpawnAlly.ToString(), SpawnAlly);
    }
    private void OnDisable()
    {
        EventDispatcher<string>.RemoveListener(Event.SpawnAlly.ToString(), SpawnAlly);
    }

    private void SpawnAlly(string name)
    {
        foreach (Ally ally in characterList)
        {
            if (ally.name == name)
            {
                Instantiate(ally.allyPrefab, GameManager.Instance.spawnAllyPos, Quaternion.identity);
            }    
        }
    }    
}

[System.Serializable]
public class Ally
{
    public string name;
    public string ID;
    public GameObject allyPrefab;
}
