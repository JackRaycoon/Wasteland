using System;
using UnityEngine;
using UnityEngine.AI;

public class Bootstrap : MonoBehaviour
{
    public Character character;
    public GameObject resourcePrefab;

    private ResourceFabric resourceFabric;
    private CharacterController characterController;
    private static NavMeshAgent agent;
    void Start()
    {
        agent = character.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;

        characterController = new(character);
        resourceFabric = new(resourcePrefab, characterController);
    }

    private void OnDestroy()
    {
        resourceFabric.Dispose();
    }

    internal static NavMeshAgent GetAgent()
    {
        return agent;
    }
}
