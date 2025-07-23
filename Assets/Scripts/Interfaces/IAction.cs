using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IAction
{
    UniTask Interact(IObject executor, IObject target, Task task = null);
}
