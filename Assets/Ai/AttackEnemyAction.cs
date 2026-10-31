using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AttackEnemy", story: "AttackEnemy", category: "Action", id: "4420f19c0fd750ad3401817caf14e3d1")]
public partial class AttackEnemyAction : Action
{

    protected override Status OnStart()
    {
        GameObject.GetComponent<Enemy>().Attack();
        return Status.Success;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

