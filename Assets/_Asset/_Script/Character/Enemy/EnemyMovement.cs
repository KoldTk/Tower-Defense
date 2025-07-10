using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public MovePath movePath;
    public float moveSpeed;
    private int nextIndex = 1;
    private void Update()
    {
        if ((movePath == null)) return;
        if (nextIndex >= movePath.waypoints.Length) return;
        if (transform.position != movePath[nextIndex])
        {
            MoveToNextWaypoint();
            LookAtDirection(movePath[nextIndex]);
        }
        else
        {
            nextIndex++;
        }
        
    }

    private void MoveToNextWaypoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePath[nextIndex], moveSpeed * Time.deltaTime);
    }
    private void LookAtDirection(Vector2 destination)
    {
        Vector2 currentPosition = transform.position;
        var lookDirection = destination - currentPosition;
        if (lookDirection.magnitude < 0.01f) return;
        var angle = Vector2.Angle(Vector3.zero, lookDirection);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }    
}
