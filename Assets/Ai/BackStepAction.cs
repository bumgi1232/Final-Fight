using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "BackStep", story: "BackStep", category: "Action", id: "f06aa6a8b819f3c0dbff3b225bdf5c70")]
public partial class BackStepAction : Action
{
    [SerializeReference]
    public BlackboardVariable<Transform> targetTransform;
    int rand;
    
    Vector3 backDir;
    float speed = 8f;
    float duration = 1.5f;
    float timer;

    protected override Status OnStart()
    {
        rand = UnityEngine.Random.Range(0, 2);
        Vector3 direction = (GameObject.transform.position - targetTransform.Value.position);
        Debug.Log(rand);
        direction.z = 0f;
        backDir = direction.normalized;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;
        
        if(rand == 0)
        {
            if (timer >= duration)
            {
                timer = 0;
                return Status.Success;
            }

            GameObject.GetComponent<Enemy>().BackStep(backDir * speed);
            return Status.Running;
        }
        else
        {
            return Status.Failure;
        }
    }

    protected override void OnEnd()
    {
        
    }
}

