using Cysharp.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ResourceFabric
{
    private List<GameObject> spawnedResourceList = new();
    private List<Vector2> filledCells = new();

    private GameObject resourcePrefab;
    private CharacterController characterController;

    private CancellationTokenSource cts;

    public ResourceFabric(GameObject resourcePrefab, CharacterController characterController)
    {
        this.resourcePrefab = resourcePrefab;
        this.characterController = characterController;
        cts = new CancellationTokenSource();
        Tick(cts.Token).Forget();
    }

    async UniTask Tick(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await UniTask.Delay(1000, cancellationToken: token);
            CreateResource();
        }
    }

    private void CreateResource()
    {
        spawnedResourceList.RemoveAll(obj => obj == null);

        if (spawnedResourceList.Count < 5)
        {
            Vector2 coords;
            do
            {
                float x = Random.Range(-4, 5);
                float z = Random.Range(-4, 5);
                coords = new Vector2(x, z);
            } while (filledCells.Contains(coords));

            filledCells.Add(coords);
            
            Vector3 vector = new(coords.x, resourcePrefab.transform.position.y, coords.y);
            GameObject go = MonoBehaviour.Instantiate(resourcePrefab, vector, resourcePrefab.transform.rotation);
            spawnedResourceList.Add(go);
            characterController.GiveTask(new(ActionDB.Collect, go.GetComponent<Resource>()));
        }
    }

    public void Dispose()
    {
        cts.Cancel();
        cts.Dispose();
    }
}
