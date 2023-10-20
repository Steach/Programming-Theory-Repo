using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FloorObjectSpawner))]
public class SceneSpawner : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Spawn Objects"))
        {
            FloorObjectSpawner spawner = (FloorObjectSpawner)target;
            spawner.SpawnObject();
        }
    }
}
