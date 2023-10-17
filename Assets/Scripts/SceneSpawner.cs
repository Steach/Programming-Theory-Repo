using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectSpawner))]
public class SceneSpawner : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Spawn Objects"))
        {
            ObjectSpawner spawner = (ObjectSpawner)target;
            spawner.SpawnObject();
        }
    }
}
