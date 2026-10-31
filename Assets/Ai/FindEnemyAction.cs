using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindEnemy", story: "FindEnemy", category: "Action", id: "ecb17b46436b4e910857b1f529623c42")]
public partial class FindEnemyAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Transform> targetTransform;

    float detectionDistance = 8;

    float minDistance = 1;

    protected override Status OnStart()
    {
        Vector3 agentPosition = GameObject.transform.position;
        Vector3 playerPosition = targetTransform.Value.position;
        float distance = Vector3.Distance(agentPosition, playerPosition);
        if (detectionDistance < distance || distance < minDistance )
        {
            return Status.Failure;
        }

        else
        {
            return Status.Success;
        }
        
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

