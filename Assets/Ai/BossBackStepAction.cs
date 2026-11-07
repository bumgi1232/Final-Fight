using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BossBackStep", story: "BossBackStep", category: "Action", id: "9156db3f94b015afd2b578b0e8b33095")]
public partial class BossBackStepAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Transform> targetTransform;

    Vector3 backDir;
    float duration = 3f;
    float timer;
    float speed = 8f;

    protected override Status OnStart()
    {
        Vector3 direction = (GameObject.transform.position - targetTransform.Value.position);
        direction.z = 0f;
        backDir = direction.normalized;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            timer = 0;
            return Status.Success;
        }
        GameObject.GetComponent<Enemy>().BackStep(GameObject.transform.position + backDir * speed);
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

