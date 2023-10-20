using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawner : ObjectSpawner
{
    public GameObject gameObjectForMesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObjects()
    {
        SetSteps();
        Vector3 spawnPosition = new Vector3 (xStart, yStart, zStart);
        Quaternion spawnRotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        for(int i = 0; i < countOfSpawnX; i++)
        {
            for(int j = 0; j < countOfSpawnZ; j++)
            {
                spawnPosition = new Vector3(xStart + (j * (xStep - 3)), yStart + (i * yStep), zStart + (i * zStep));
                Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            }  
        }
    }

    private void SetSteps()
    {
        if(gameObjectForMesh != null)
        {
            MeshRenderer meshRenderer = gameObjectForMesh.GetComponent<MeshRenderer>();
            Vector3 objectSize = meshRenderer.bounds.size;
            float objectX = objectSize.x;
            float objectY = objectSize.y;
            float objectZ = objectSize.z;
            xStep = objectX;
            zStep = objectZ;
        } 
        else 
        {
            Debug.Log("ADD MESHRENDER OBJECT!");
        }
        
    }
}
