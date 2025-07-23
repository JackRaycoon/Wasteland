using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour, IObject
{
    public string Name => "Floor";
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
