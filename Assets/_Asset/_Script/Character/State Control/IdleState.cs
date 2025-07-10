using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T>: ICharacterState<T> where T : MonoBehaviour
{
    public void Enter(T character)
    {
        Debug.Log("Is idle");
    }

    public void Exit(T character)
    {

    }

    public void Update(T character)
    {

    }
}
