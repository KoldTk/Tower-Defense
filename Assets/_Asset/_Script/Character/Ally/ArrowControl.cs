using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    private Transform target;
    private float arrowSpeed;
    private void Update()
    {
        TargetEnemy();
        FlyToEnemy();
    }
    private void TargetEnemy()
    {
        Vector3 attackDirection = target.position - transform.position;
        if (attackDirection.magnitude < 0.01f) return;
        var arrowAngle = Vector2.SignedAngle(Vector3.right, attackDirection);
        transform.rotation = Quaternion.Euler(0, 0, arrowAngle);
    }
    private void FlyToEnemy()
    {
        transform.position = Vector3.MoveTowards(
               transform.position,
               target.position,
               arrowSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            DealDamage();
            gameObject.SetActive(false);
        }
    }
    public void SetTargetForArrow(Transform target, float arrowSpeed)
    {
        this.target = target;
        this.arrowSpeed = arrowSpeed;
    }
    public void DealDamage()
    {
        EnemyInfo targetInfo = target.GetComponent<EnemyInfo>();
        AllyControl ally = transform.parent.GetComponent<AllyControl>();
        ally.arrowPool.Enqueue(gameObject);
        float damageDeal = ally.allyData.strength - targetInfo.enemyData.defense;
        damageDeal = Mathf.Clamp(damageDeal, 0, ally.allyData.strength);
        targetInfo.TakeDamage(damageDeal, ally.enemiesInRange, ally.animator);
    } 
}
