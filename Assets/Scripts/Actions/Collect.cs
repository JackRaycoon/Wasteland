using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Collect : IAction
{
    public NavMeshAgent agent => Bootstrap.GetAgent();

    async UniTask IAction.Interact(IObject executor, IObject target, Task task)
    {
        IAction action = ActionDB.GoTo;
        await action.Interact(executor, target);

        await UniTask.Delay(2000);

        target.Destroy();

        if (task is not null)
            task.isComplete = true;
    }

}
