using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyStateController : MonoBehaviour
{
    private const string ENEMY_KEY = "Enemy";
    private CharacterStateManager<AllyStateController> stateManager;
    public int blockCount;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        stateManager = new CharacterStateManager<AllyStateController>(this);
        stateManager.ChangeState(new IdleState<AllyStateController>());
    }

    void Update()
    {
        stateManager.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_KEY))
        {
            if (blockCount > 0)
            {
                blockCount--;
                stateManager.ChangeState(new AttackState<AllyStateController>());
            }     
        }    
    }
}
