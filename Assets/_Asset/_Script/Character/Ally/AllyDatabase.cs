using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Database/Create ally", fileName = "New ally")]
public class AllyDatabase : ScriptableObject
{
    public string ID;
    public string characterName;
    public float health;
    public float defense;
    public float strength;
    public float attackSpeed;
}
