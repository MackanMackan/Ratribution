
using UnityEngine;
using UnityEditor;
using System;

public class TestWindow : EditorWindow
{
    //string myString = "Hej";
    Color color;

    [MenuItem("Window/Colorize")]

    //Draw the window
    public static void ShowWindow()
    {
        GetWindow<TestWindow>("Colorize");
    }

    //Window Code
    private void OnGUI()
    {
        GUILayout.Label("Color Selected Objects", EditorStyles.boldLabel);
        GUILayout.Space(20f);

        //myString = EditorGUILayout.TextField("Name", myString);
        color = EditorGUILayout.ColorField("Color", color);
        GUILayout.Space(10f);

        if (GUILayout.Button("Colorize"))
        {
            Colorize();           
        }

        if (GUILayout.Button("Undo"))
        {
            UndoColor();
        }
    }

    private void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            
            Renderer renderer = obj.GetComponent<Renderer>();
            Undo.RecordObject(renderer, "Changing Color");

            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;             
            }
        }
    }

    private void UndoColor()
    {
        Undo.PerformUndo();
    }
}
