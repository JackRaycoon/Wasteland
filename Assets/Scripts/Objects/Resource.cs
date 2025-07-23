using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, IObject
{
    public string Name => "Resource";
    public GameObject gameObj => gameObject;
    public void Destroy()
    {
        Destroy(gameObj);
    }

    public IEnumerable<IAction> GetAvailableActions()
    {
        yield return ActionDB.GoTo;
        //yield return ActionDB.PickUp;
        //yield return ActionDB.Talk;
    }
}
