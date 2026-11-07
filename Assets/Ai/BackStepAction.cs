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
    float duration = 1.5f;
    float timer;
    bool isback = false;
    float speed = 5f;

    protected override Status OnStart()
    {
        rand = UnityEngine.Random.Range(0, 2);
        Vector3 direction = GameObject.transform.position - targetTransform.Value.position;
        direction.z = 0f;
        backDir = direction.normalized;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        timer += Time.deltaTime;
        
        if(rand == 0 && !isback)
        {
            if (timer >= duration)
            {
                timer = 0;
                isback = true;
                return Status.Success;
            }

            GameObject.GetComponent<Enemy>().BackStep(GameObject.transform.position+backDir * speed);
            return Status.Running;
        }
        else
        {
            isback = false;
            return Status.Failure;
        }
    }

    protected override void OnEnd()
    {
        
    }
}

