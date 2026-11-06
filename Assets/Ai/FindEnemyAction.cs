using System;
using Unity.Behavior;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Splines;
using Action = Unity.Behavior.Action;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "FindEnemy", story: "FindEnemy", category: "Action", id: "ecb17b46436b4e910857b1f529623c42")]
public partial class FindEnemyAction : Action
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
            GameObject.GetComponent<Enemy>().Stop();
            return Status.Running;
        }
        else
        {
            return Status.Success;
        }
        
    }

    protected override void OnEnd()
    {
    }
}

