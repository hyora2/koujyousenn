using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DrawLine))]
public class DrawLine_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawLine drawLine = (DrawLine)target;

        serializedObject.Update();

        DrawDefaultInspector();

        if (!drawLine.deleteSoon)
        {
            GUILayout.Label("何秒後に消すか");
            drawLine.deleteTime = EditorGUILayout.Slider("destroyLineTime", drawLine.deleteTime, 1, 60);
        }

        serializedObject.ApplyModifiedProperties();
    }
}