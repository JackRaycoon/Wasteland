using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class GoTo : IAction
{
    public NavMeshAgent agent => Bootstrap.GetAgent();

    async UniTask IAction.Interact(IObject executor, IObject target, Task task)
    {
        Transform targetTransform = target.gameObj.transform;
        NavMeshAgent agent = executor.gameObj.GetComponent<NavMeshAgent>();

        agent.SetDestination(targetTransform.position);

        while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance + 0.05f)
        {
            await UniTask.Yield();
        }

        if(task is not null)
            task.isComplete = true;
    }

}
