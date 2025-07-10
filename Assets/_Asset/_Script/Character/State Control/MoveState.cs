using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState<T> : ICharacterState<T> where T : MonoBehaviour
{
    private int nextIndex = 1;
    public void Enter(T character)
    { 
    }

    public void Exit(T character)
    {

    }

    public void Update(T character)
    {
        HandleEnemyMove(character);
    }
    private void MoveToNextWaypoint(T character)
    {
        if (character is EnemyStateController enemy)
        {
            float moveSpeed = enemy.moveSpeed * Time.deltaTime;
            character.transform.position = Vector3.MoveTowards(character.transform.position, enemy.movePath[nextIndex], moveSpeed);
        }      
    }
    private void LookAtDirection(Vector2 destination, T character)
    {
        Vector2 currentPosition = character.transform.position;
        var lookDirection = destination - currentPosition;
        if (lookDirection.magnitude < 0.01f) return;
        var angle = Vector2.Angle(Vector3.zero, lookDirection);
        character.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void HandleEnemyMove(T character)
    {
        if ((character is EnemyStateController enemy))
        {
            if ((enemy.movePath == null)) return;
            if (nextIndex >= enemy.movePath.waypoints.Length) return;
            if (character.transform.position != enemy.movePath[nextIndex])
            {
                MoveToNextWaypoint(character);
                LookAtDirection(enemy.movePath[nextIndex], character);
            }
            else
            {
                nextIndex++;
            }
        }
    }
}
