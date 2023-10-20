using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

[CustomEditor(typeof(WallsSpawner))]
public class WallEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Spawn Walls"))
        {
            WallsSpawner spawner = (WallsSpawner)target;
            spawner.SpawnObjects();
        }
    }
}
