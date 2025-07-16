using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState<T> : ICharacterState<T> where T : MonoBehaviour
{
    public void Enter(T character)
    {
        if (character is EnemyStateController enemy)
        {
            enemy.animator.SetTrigger("Attack");
        }
        if (character is AllyStateController ally)
        {
            ally.animator.SetTrigger("Attack");
            Debug.Log("Attack");
        }
    }
    public void Exit(T character)
    {
        if (character is EnemyStateController enemy)
        {
            enemy.animator.SetTrigger("Move");
        }
        if (character is AllyStateController ally)
        {
            ally.animator.SetTrigger("Idle");
        }
    }

    public void Update(T character)
    {

    }
}
