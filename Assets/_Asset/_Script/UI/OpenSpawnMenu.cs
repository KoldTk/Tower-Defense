using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSpawnMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0.1f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
