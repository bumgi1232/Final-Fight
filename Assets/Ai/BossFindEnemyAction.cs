using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossFindEnemy", story: "BossFindEnemy", category: "Action", id: "90e6da0fe0c0ef94d36e9e8835cd247f")]
public partial class BossFindEnemyAction : Action
{

    [SerializeReference]
    public BlackboardVariable<Transform> targetTransform;

    float detectionDistance = 8;
    float minDistance = 3;
    float distance;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector3 agentPosition = GameObject.transform.position;
        Vector3 playerPosition = targetTransform.Value.position;

        distance = Vector3.Distance(agentPosition, playerPosition);

        if (distance < minDistance)
        {
            return Status.Failure;
        }
        else if (detectionDistance < distance)
        {
            return Status.Failure;
        }
        else
        {
            return Status.Success;
        }
    }
}

