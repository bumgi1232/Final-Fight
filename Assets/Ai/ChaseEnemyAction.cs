using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using Unity.VisualScripting;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChaseEnemy", story: "ChaseEnemy", category: "Action", id: "5fe9b8863ab619ac931430516848d37a")]
public partial class EnemyChaseAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Transform> targetTransform;
    [SerializeReference]
    public BlackboardVariable<float> yTolerance = new BlackboardVariable<float>(0.3f);
    [SerializeReference]
    public BlackboardVariable<float> attackRangeX = new BlackboardVariable<float>(3.0f);
    [SerializeReference]
    public BlackboardVariable<float> moveSpeed = new BlackboardVariable<float>(3.0f);

    float minDistance = 3;

    protected override Status OnStart()
    {
        return Status.Running;        
    }

    protected override Status OnUpdate()
    {
        Vector3 currentPosition = GameObject.transform.position;
        Vector3 playerPosition = targetTransform.Value.position;

        float distance = Vector3.Distance(currentPosition, playerPosition);
        float deltaY = Mathf.Abs(currentPosition.y - playerPosition.y);
        float deltaX = Mathf.Abs(currentPosition.x - playerPosition.x);

        if (deltaY <= yTolerance && deltaX <= minDistance)
        {
            GameObject.GetComponent<Enemy>().Stop();
            return Status.Failure;
        }

        Vector3 direction = currentPosition;
        if (deltaY > yTolerance.Value)
        {
            direction.y = playerPosition.y;
        }

        else
        {
            direction.x = playerPosition.x;
        }
        GameObject.GetComponent<Enemy>().MoveToWithNav(direction);

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

