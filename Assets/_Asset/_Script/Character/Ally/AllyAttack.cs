using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    private const string ENEMY_KEY = "Enemy";
    private Animator animator;
    public AllyDatabase allyData;
    private List<EnemyDatabase> enemiesInRange = new();
    private float attackCooldown;
    [SerializeField] private GameObject arrowPrefab;
    public Queue<GameObject> arrowPool = new Queue<GameObject>();
    [SerializeField] private int arrowPoolSize = 5;
    private ArrowControl arrowControl;
    void Start()
    {
        SpawnArrow();
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

        EnemyInfo enemyInfo = target.GetComponent<EnemyInfo>();
        if (!enemiesInRange.Contains(enemyInfo.enemyData))
        {
            enemiesInRange.Add(enemyInfo.enemyData);
        }
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        if (!target.CompareTag(ENEMY_KEY)) return;

        EnemyInfo enemyInfo = target.GetComponent<EnemyInfo> ();
        enemiesInRange.Remove(enemyInfo.enemyData);
    }
    private void OnTriggerStay2D(Collider2D target)
    {
        EnemyInfo enemyInfo = target.GetComponent<EnemyInfo>();

        if (attackCooldown <= 0)
        {
            if (enemyInfo != null)
            {
                Attack(enemyInfo);
            }
            else
            {
                enemyInfo = target.GetComponent<EnemyInfo>();
                Attack(enemyInfo);
            }
            DealDamage(enemyInfo);
            attackCooldown = 1 / allyData.attackSpeed;
        }
    }
    private void Attack(EnemyInfo enemy)
    {
        animator.SetTrigger("Attack");
        GameObject arrow = arrowPool.Dequeue();
        arrowControl = arrow.GetComponent<ArrowControl>();
        arrowControl.enemyPos = enemy.transform.position;
        arrow.SetActive(true);
    }  
    public void DealDamage(EnemyInfo enemy)
    {
        float damageDeal = allyData.strength - enemy.enemyData.defense;
        damageDeal = Mathf.Clamp(damageDeal, 1, allyData.strength);
        enemy.TakeDamage(damageDeal, enemiesInRange, animator);
    } 
    private void SpawnArrow()
    {
        for (int i = 0; i < arrowPoolSize; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation, transform);
            arrow.SetActive(false);
            arrowPool.Enqueue(arrow);
        }
    }    
}
