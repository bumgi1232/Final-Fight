using UnityEngine;

public class LockOn : MonoBehaviour
{
    [Header("록 온 설정")]
    public float lockOnRange = 8f;
    public float lockOutRange = 12f;
    public LayerMask enemyLayer;

    private Transform currentTarget;
    private Enemy enemy;

    private void Update()
    {
        if (currentTarget == null)
        {
            FindAndLockNearestEnemy();
        }
        else
        {
            if (currentTarget == null || !currentTarget.gameObject.activeSelf)
            {
                ClearLockOn();
                return;
            }

            float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

            if(distanceToTarget > lockOutRange)
            {
                ClearLockOn();
            }
        }
    }

    void FindAndLockNearestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, lockOnRange, enemyLayer);

        float shortestDistance = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach(Collider2D col in colliders)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, col.transform.position);

            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = col.transform;
            }
        }

        if(nearestEnemy != null)
        {
            currentTarget = nearestEnemy;
            enemy = currentTarget.GetComponent<Enemy>();

            if(enemy != null && TargetHealthUi.Instance != null)
            {
                TargetHealthUi.Instance.ShowTargetUI(currentTarget, enemy);
            }
        }
    }

    void ClearLockOn()
    {
        if(TargetHealthUi.Instance != null)
        {
            TargetHealthUi.Instance.HideTargetUI();
        }

        currentTarget = null;
        enemy = null;
    }    
}
