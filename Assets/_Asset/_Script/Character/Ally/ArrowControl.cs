using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    public Vector3 enemyPos;
    private AllyAttack ally;
    [SerializeField] private float arrowSpeed;
    private void Start()
    {
        ally = GetComponentInParent<AllyAttack>();
    }
    private void OnEnable()
    {
        TargetEnemy();
        StartCoroutine(FlyToEnemy());
    }
    private void TargetEnemy()
    { 
        Vector3 attackDirection = enemyPos - transform.position;
        if (attackDirection.magnitude < 0.01f) return;
        var arrowAngle = Vector2.SignedAngle(Vector3.right, attackDirection);
        transform.rotation = Quaternion.Euler(0, 0, arrowAngle);
    }    
    private IEnumerator FlyToEnemy()
    {
        while (Vector3.Distance(transform.position, enemyPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                enemyPos,
                arrowSpeed * Time.deltaTime
            );
            yield return null;
        }
        gameObject.SetActive(false);
        transform.position = transform.parent.position;
        ally.arrowPool.Enqueue(gameObject);
        
    }
}
