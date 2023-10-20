using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StairsSpawner))]
public class StairEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Spawn Stairs"))
        {
            StairsSpawner spawner = (StairsSpawner)target;
            spawner.SpawnObjects();
        }
    }
}
