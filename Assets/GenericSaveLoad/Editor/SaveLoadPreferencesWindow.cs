using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SaveLoadPreferencesWindow : EditorWindow
{
    private string folder;
    private string extension;
    private string defaultName;

    private List<ITypedSerializationSurrogate> handlers = new List<ITypedSerializationSurrogate>();

    [MenuItem("Window/Save System Preferences")]
    static void OpenWindow()
    {
        SaveLoadPreferencesWindow window = GetWindow<SaveLoadPreferencesWindow>(utility: true, title: "Edit Save System Preferences", focus: true);
        window.minSize = new Vector2(600, 300);
        window.maxSize = new Vector2(900, 450);
        window.Show();
    }

    private void OnEnable()
    {
        this.LoadPreferences();
    }

    private void LoadPreferences()
    {
        SaveLoadPreferences prefs = Resources.Load<SaveLoadPreferences>(Constants.SAVE_LOAD_PREFERENCES_FILENAME);
        this.folder = prefs.saveFolder;
        this.extension = prefs.saveExtension;
        this.defaultName = prefs.defaultSaveName;

        this.handlers.AddRange(prefs.serilizationHandlers);
    }

    private void OnGUI()
    {
        this.DrawLayouts();
        this.DrawHeader();
        this.DrawTextFields();
        this.DrawHandlerField();
    }

    private void DrawLayouts()
    {
        return;
    }

    private void DrawHeader()
    {
        return;
    }

    private void DrawTextFields()
    {
        return;
    }

    private void DrawHandlerField()
    {
        return;
    }

}
