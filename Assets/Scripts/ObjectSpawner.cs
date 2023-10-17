using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject prefabToSpawn;
    public int numberOfSpawn;
    public float y;
    public float z;
    public float xStep;
    public float zStep;
    public float xStart;
    public float zstart;
    public bool xORz;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        for (int i = 0; i < numberOfSpawn; i++)
        {
            Vector3 spawnPosition = new Vector3(0,0,0);

            if(xORz)
            {
                spawnPosition = new Vector3(xStart + (i * xStep), y, z);
            }
            
            if(!xORz)
            {
                spawnPosition = new Vector3(xStart, y, z - (i * zStep));
            }
            

            Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
            Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        }
    }
}
