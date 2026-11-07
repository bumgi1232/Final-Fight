using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting.FullSerializer;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossRush", story: "RushToPlayer", category: "Action", id: "60d0d5937e194e843a93d19ef5f36d54")]
public partial class BossRushAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Transform> targetTransform;
   
    float playerToBossDistance = 2f;

    protected override Status OnStart()
    {        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        float distance = Vector3.Distance(targetTransform.Value.position, GameObject.transform.position);

        if (distance < playerToBossDistance)
        {
            return Status.Failure;
        }
        
        GameObject.GetComponent<Enemy>().Rush(targetTransform.Value.position);
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

