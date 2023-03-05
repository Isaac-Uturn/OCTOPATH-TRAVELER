using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestWindow : EditorWindow
{
    [MenuItem("MyTool/Open My Tool %g")]

    static void Open()
    {
        var window = GetWindow<TestWindow>();
        window.title = "MyTool";
    }


    private void OnGUI()
    {
        EditorGUILayout.LabelField("Label");
        EditorGUILayout.TextField("Text");
        GUILayout.Button("Button");
    }
}
