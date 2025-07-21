using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyControl : MonoBehaviour
{
    private const string ENEMY_KEY = "Enemy";
    public Animator animator;
    public AllyDatabase allyData;
    public List<EnemyDatabase> enemiesInRange = new();
    private float attackCooldown;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private int arrowPoolSize = 5;
    [SerializeField] private float arrowSpeed;
    public Queue<GameObject> arrowPool = new Queue<GameObject>();
    private Vector3 originalScale;
    void Start()
    {
        CreateArrowPool();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale;
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

        EnemyInfo enemyInfo = target.GetComponent<EnemyInfo>();
        enemiesInRange.Remove(enemyInfo.enemyData);
    }
    private void OnTriggerStay2D(Collider2D target)
    {
        if (!target.CompareTag(ENEMY_KEY)) return;
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
            attackCooldown = 1 / allyData.attackSpeed;
        }
    }
    private void Attack(EnemyInfo enemy)
    {
        animator.SetTrigger("Attack");
        RotateCharacter(enemy);
        ShootArrow(enemy.transform, arrowSpeed);
        SetCharacterToDefault();
    }  
    private void ShootArrow(Transform target, float arrowSpeed)
    {
        GameObject arrow = arrowPool.Dequeue();
        ArrowControl arrowControl = arrow.GetComponent<ArrowControl>();
        arrow.transform.position = transform.position;
        arrow.SetActive(true);
        arrowControl.SetTargetForArrow(target, arrowSpeed);
    }
    private void CreateArrowPool()
    {
        for (int i = 0; i < arrowPoolSize; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation,transform);
            arrowPool.Enqueue(arrow);
            arrow.SetActive(false);
        }
    }
    private void RotateCharacter(EnemyInfo target)
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;

        float dotRight = Vector2.Dot(direction, Vector2.right);
        float dotUp = Vector2.Dot(direction, Vector2.up);
        if (Mathf.Abs(dotRight) > Mathf.Abs(dotUp))
        {
            transform.localScale = new Vector3(2 * Mathf.Sign(dotRight), 2f, 2f);
        }
        else
        {
            Debug.Log("Attack Enemy Down");
        }  
    }
    private void SetCharacterToDefault()
    {
        if (enemiesInRange.Count == 0)
        {
            transform.localScale = originalScale;
        }    
    }    
}
