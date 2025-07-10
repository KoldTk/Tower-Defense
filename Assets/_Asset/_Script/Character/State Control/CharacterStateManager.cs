using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager<T>
{
    private ICharacterState<T> currentState;
    private T character;
    
    public CharacterStateManager(T character)
    {
        this.character = character;
    }
    public void ChangeState(ICharacterState<T> newState)
    {
        currentState?.Exit(character);
        currentState = newState;
        currentState?.Enter(character);
    }
    public void Update()
    {
        currentState?.Update(character);
    }
}
