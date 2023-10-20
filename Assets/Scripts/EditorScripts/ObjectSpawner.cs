using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected float xStart;
    [SerializeField] protected float yStart;
    [SerializeField] protected float zStart;
    [SerializeField] protected float xStep;
    [SerializeField] protected float zStep;
    [SerializeField] protected float yStep;
    [SerializeField] protected int countOfSpawnX;
    [SerializeField] protected int countOfSpawnY;
    [SerializeField] protected int countOfSpawnZ;
    [SerializeField] protected float xRotation;
    [SerializeField] protected float yRotation;
    [SerializeField] protected float zRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
