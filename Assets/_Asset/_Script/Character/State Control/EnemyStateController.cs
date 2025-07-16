using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{
    private const string PLAYER_KEY = "Player";
    private CharacterStateManager<EnemyStateController> stateManager;
    public float moveSpeed;
    public MovePath movePath;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        stateManager = new CharacterStateManager<EnemyStateController>(this);
        stateManager.ChangeState(new MoveState<EnemyStateController>());
    }
    void Update()
    {
        stateManager.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_KEY))
        {
            var player = collision.GetComponent<AllyStateController>();
            if (player.blockCount > 0)
            {
                stateManager.ChangeState(new AttackState<EnemyStateController>());
            }    
        }    
    }
}
