using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ManualController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    private void Start()
    {
        agent.updateRotation = false;
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("GO");
                agent.SetDestination(hit.point);
            }
        }
    }
}
