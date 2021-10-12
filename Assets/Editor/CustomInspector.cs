using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveLoadPreferences))]
public class CustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SaveLoadPreferences savePref = target as SaveLoadPreferences;

        if (GUILayout.Button("Test Button"))
        {
            Debug.Log("Test pressed.");
        }
    }
}
