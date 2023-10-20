using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLocalScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Vector3 objectSize = meshRenderer.bounds.size;
        float objectX = objectSize.x;
        float objectY = objectSize.y;
        float objectZ = objectSize.z;

        Debug.Log("X: " + objectX);
        Debug.Log("Y: " + objectY);
        Debug.Log("Z: " + objectZ);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
