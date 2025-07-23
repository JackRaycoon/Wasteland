using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IObject
{
    internal List<Task> taskList = new();

    private Task currentTask = null;
    public string Name => "NPC";

    public GameObject gameObj => gameObject;

    public void Destroy()
    {
        Destroy(gameObj);
    }

    public IEnumerable<IAction> GetAvailableActions()
    {
        yield return null;
    }

    private void Update()
    {
        if (currentTask != null && currentTask.isComplete)
        {
            currentTask = null;
        }


        if (taskList.Count > 0 
        && currentTask == null)
        {
            currentTask = taskList[0];
            currentTask.action.Interact(this, currentTask.obj, currentTask);
            taskList.Remove(currentTask);
        }
    }
}
