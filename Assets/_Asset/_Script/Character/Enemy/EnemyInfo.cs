using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public EnemyDatabase enemyData;

    public float currentHealth;

    private void Start()
    {
        currentHealth = enemyData.health;
    }
    private void OnDestroy()
    {

    }

    public void TakeDamage(float damage, List<EnemyDatabase> enemyInRange, Animator allyAnimator)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            EnemyDie();
            if (enemyInRange.Count <= 0)
            {
                allyAnimator.SetTrigger("Idle");
            }
            Destroy(gameObject);
        }    
        Debug.Log("Enemy Health: " + currentHealth);
    }
    private void EnemyDie()
    {
        EventDispatcher<int>.Dispatch(Event.GainGold.ToString(), enemyData.goldDrop);
        EventDispatcher<float>.Dispatch(Event.GainExp.ToString(), enemyData.expDrop);
    }    
}
