using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType{attack, defense, ultility}

[CreateAssetMenu(menuName = "Card Database/Create Card", fileName = "New Card")]
public class BuffCardDatabase : ScriptableObject
{
    public string cardName;
    public string description;
    public BuffType type;
    public float buffValue;   
}
