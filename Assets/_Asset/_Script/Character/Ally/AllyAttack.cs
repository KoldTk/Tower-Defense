using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AllyAttack : MonoBehaviour
{
    private const string ENEMY_KEY = "Enemy";
    public Animator animator;
    public AllyDatabase allyData;
    private List<EnemyDatabase> enemiesInRange = new();
    private float attackCooldown;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        attackCooldown = 1 / allyData.attackSpeed;
    }
    private void Update()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }    
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (!target.CompareTag(ENEMY_KEY)) return;

        var enemy = target.GetComponent<EnemyInfo>();
        if (!enemiesInRange.Contains(enemy.enemyData))
        {
            enemiesInRange.Add(enemy.enemyData);
        }
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        if (!target.CompareTag(ENEMY_KEY)) return;

        var enemy = target.GetComponent<EnemyInfo> ();
        enemiesInRange.Remove(enemy.enemyData);
    }
    private void OnTriggerStay2D(Collider2D target)
    {
        var enemy = target.GetComponent<EnemyInfo>();

        if (attackCooldown <= 0)
        {
            if (enemy != null)
            {
                Attack();
            }
            else
            {
                enemy = target.GetComponent<EnemyInfo>();
                Attack();
            }
            float dmg = DealDamage(enemy.enemyData.defense);
            enemy.TakeDamage(dmg, enemiesInRange, animator);
            attackCooldown = 1 / allyData.attackSpeed;
        }
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
        Debug.Log("Attack");
    }  
    private float DealDamage(float enemyDefense)
    {
        float damageDeal = allyData.strength - enemyDefense;
        damageDeal = Mathf.Clamp(damageDeal, 1, allyData.strength);
        return damageDeal;
    }    
}
