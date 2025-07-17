using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Database/Create enemy", fileName = "New enemy")]
public class EnemyDatabase : ScriptableObject
{
    public string ID;
    public string characterName;
    public float health;
    public float defense;
    public float strength;
    public float attackSpeed;
    public float movementSpeed;
    public float expDrop;
    public int goldDrop;
}
