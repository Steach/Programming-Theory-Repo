using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorObjectSpawner : ObjectSpawner
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetSteps()
    {
        MeshRenderer meshRenderer = prefabToSpawn.GetComponent<MeshRenderer>();
        Vector3 objectSize = meshRenderer.bounds.size;
        float objectX = objectSize.x;
        float objectY = objectSize.y;
        float objectZ = objectSize.z;
        xStep = objectX;
        zStep = objectZ;
    }

    public void SpawnObject()
    {
        SetSteps();
        for (int i = 0; i < countOfSpawnZ; i++)
        {
            Vector3 spawnPosition = new Vector3(0, 0, 0);
            for (int j = 0; j < countOfSpawnX; j++)
            {
                spawnPosition = new Vector3(xStart + (j * xStep), yStart, zStart + (i * zStep));
                Quaternion spawnRotation = Quaternion.Euler(xRotation, yRotation, 0);
                Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            }
        }
    }
}
