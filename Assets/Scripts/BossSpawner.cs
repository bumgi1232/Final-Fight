using UnityEngine;
using Unity.Behavior;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject BossPrefab;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] Stage2 stage;
    public void SpawnBoss()
    {        
        GameObject BossInstance = Instantiate(BossPrefab);
        EnemyLookAtPlayer enemyLookAtPlayer = BossInstance.GetComponent<EnemyLookAtPlayer>();
        Enemy enemy = BossInstance.GetComponent<Enemy>();
        BehaviorGraphAgent agent = BossInstance.GetComponent<BehaviorGraphAgent>();
        enemyLookAtPlayer.playerTransform = PlayerTransform;
        enemy.stage2 = stage;
        agent.SetVariableValue("targetTransform", PlayerTransform);
    }

}
