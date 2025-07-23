using System.Collections.Generic;
using UnityEngine;

public interface IObject
{
    string Name { get; }
    GameObject gameObj { get; }
    IEnumerable<IAction> GetAvailableActions();

    void Destroy();

}
