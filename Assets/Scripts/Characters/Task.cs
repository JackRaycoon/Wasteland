using System.Collections.Generic;
using UnityEngine;

public class Task
{
    internal int priotity = 0;
    internal IObject obj; //What object do we need to do this with?
    internal IAction action; //What should we do?
    internal bool isComplete = false;

    public Task(IAction action, IObject obj, int priotity = 0)
    {
        this.obj = obj;
        this.action = action; 
        this.priotity = priotity;
    }
}
