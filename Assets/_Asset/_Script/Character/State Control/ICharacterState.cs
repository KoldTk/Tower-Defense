using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState<T>
{
    void Enter(T character);
    void Update(T character);
    void Exit(T character);
}
