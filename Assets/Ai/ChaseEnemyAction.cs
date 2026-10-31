using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChaseEnemy", story: "ChaseEnemy", category: "Action", id: "5fe9b8863ab619ac931430516848d37a")]
public partial class EnemyChaseAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Transform> targetTransform;

    float minDistance = 3;

    protected override Status OnStart()
    {
        return Status.Running;        
    }

    protected override Status OnUpdate()
    {
        Vector3 currentPosition = GameObject.transform.position;
        Vector3 destination = targetTransform.Value.position;

        if(Vector3.Distance(destination, currentPosition) < minDistance)
        {
            GameObject.GetComponent<Enemy>().Stop();
            return Status.Success;
        }
        else
        {
            GameObject.GetComponent<Enemy>().MoveToWithNav(destination);
            return Status.Running;
        }
    }

    protected override void OnEnd()
    {
    }
}

