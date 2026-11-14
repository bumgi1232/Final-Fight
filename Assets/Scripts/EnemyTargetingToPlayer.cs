using Unity.Behavior;
using UnityEngine;

public class EnemyTargetingToPlayer : MonoBehaviour
{

    [SerializeField]
    Transform playerTransform;
    BehaviorGraphAgent agent;
    private void Awake()
    {
        agent = GetComponent<BehaviorGraphAgent>();

        agent.SetVariableValue("targetTransform", playerTransform);
    }
}
