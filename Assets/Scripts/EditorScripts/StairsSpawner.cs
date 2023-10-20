using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsSpawner : ObjectSpawner
{
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
        Vector3 spawnPosition = new Vector3(xStart, yStart, zStart);
        for(int i = 0; i < countOfSpawnX; i++)
        {
            spawnPosition = new Vector3(xStart + (i * xStep), yStart + (i * yStep), zStart + (i * zStep));
            Quaternion spawnRotation = Quaternion.Euler(0, yRotation, 0);
            Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        }
    }
}
