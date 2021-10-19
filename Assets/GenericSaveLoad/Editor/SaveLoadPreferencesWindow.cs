namespace SaveLoadSystem
{
    using UnityEngine;
    using UnityEditor;
    using System.Collections.Generic;
    using UnityEditorInternal;

    public class SaveLoadPreferencesWindow : EditorWindow
    {
        private string folder;
        private string extension;
        private string defaultName;

        private string folderError = null;
        private string extensionError = null;
        private string defaultNameError = null;


        private Rect headerSection;
        private Rect defaultSettingsSection;
        private Rect handlersSection;

        private Texture2D headerTexture;
        private Texture2D defaultSettingsTexture;
        private Texture2D handlersTexture;

        private Color headerColor = new Color(50f / 255f, 100f / 255f, 100f / 255f, 1f);
        private Color defaultSettingsColor = new Color(38f / 255f, 50f / 255f, 56f / 255f, 1f);
        private Color handlersColor = new Color(38f / 255f, 50f / 255f, 56f / 255f, 1f);

        private GUISkin skin;
        private GUIStyle labelStyle;
        private GUIStyle textFieldStyle;
        private GUIStyle sublabelStyle;
        private GUIStyle textAreaStyle;
        private GUIStyle buttonStyle;

        private readonly int MARGIN = 6;

        [MenuItem("Window/Save System Preferences")]
        static void OpenWindow()
        {
            SaveLoadPreferencesWindow window = GetWindow<SaveLoadPreferencesWindow>(utility: true, title: "Edit Save System Preferences", focus: true);
            window.minSize = new Vector2(600, 700);
            window.maxSize = new Vector2(600, 900);
            window.Show();
        }

        private void OnEnable()
        {
            this.skin = Resources.Load<GUISkin>("INTERNAL_SaveLoadWindowSkin");
            this.LoadPreferences();
            this.InitTextures();
            this.InitStyles();
        }

        private void LoadPreferences()
        {
            SaveLoadPreferences prefs = Resources.Load<SaveLoadPreferences>(Constants.SAVE_LOAD_PREFERENCES_FILENAME);
            this.folder = prefs.saveFolder;
            this.extension = prefs.saveExtension;
            this.defaultName = prefs.defaultSaveName;
        }

        private void InitTextures()
        {
            this.headerTexture = new Texture2D(1, 1);
            this.headerTexture.SetPixel(0, 0, headerColor);
            this.headerTexture.Apply();

            this.defaultSettingsTexture = new Texture2D(1, 1);
            this.defaultSettingsTexture.SetPixel(0, 0, defaultSettingsColor);
            this.defaultSettingsTexture.Apply();

            this.handlersTexture = new Texture2D(1, 1);
            this.handlersTexture.SetPixel(0, 0, handlersColor);
            this.handlersTexture.Apply();
        }

        private void InitStyles()
        {
            this.labelStyle = this.skin.GetStyle("label");
            this.textFieldStyle = this.skin.GetStyle("textfield");
            this.sublabelStyle = this.skin.GetStyle("sublabel");
            this.textAreaStyle = this.skin.GetStyle("textarea");
            this.buttonStyle = this.skin.GetStyle("button");
        }

        private void OnGUI()
        {
            GUI.skin = this.skin;
            this.DrawLayouts();
            this.DrawTextFields();
            this.DrawHandlerField();
        }

        private void DrawLayouts()
        {
            this.defaultSettingsSection.x = 0 + MARGIN;
            this.defaultSettingsSection.y = 0 + MARGIN;
            this.defaultSettingsSection.width = position.width - MARGIN * 2;
            this.defaultSettingsSection.height = 200 - MARGIN;

            GUI.DrawTexture(this.defaultSettingsSection, this.defaultSettingsTexture);

            this.handlersSection.x = 0 + MARGIN;
            this.handlersSection.y = 200 + MARGIN;
            this.handlersSection.width = position.width - MARGIN * 2;
            this.handlersSection.height = position.height - 200 - MARGIN * 2;

            GUI.DrawTexture(this.handlersSection, this.handlersTexture);
        }

        private void DrawHeader()
        {
            GUILayout.BeginArea(this.headerSection);

            GUILayout.Label("Edit Save/Load System Preferences");

            GUILayout.EndArea();
        }

        private void DrawTextFields()
        {
            GUILayout.BeginArea(this.defaultSettingsSection);

            GUILayout.Label("Default Settings", this.labelStyle);

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Save/Load Folder Path", this.sublabelStyle);
            this.folder = EditorGUILayout.TextField(this.folder, this.textFieldStyle);
            GUILayout.EndHorizontal();

            GUILayout.Space(8);

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Extension", this.sublabelStyle);
            this.extension = EditorGUILayout.TextField(this.extension, this.textFieldStyle);
            GUILayout.EndHorizontal();

            GUILayout.Space(8);

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Default File Name", this.sublabelStyle);
            this.defaultName = EditorGUILayout.TextField(this.defaultName, this.textFieldStyle);
            GUILayout.EndHorizontal();

            GUILayout.EndArea();
        }

        private void DrawHandlerField()
        {
            GUILayout.BeginArea(this.handlersSection);
            GUILayout.Label("Additional Serialization Handlers", this.labelStyle);
            GUILayout.Space(20);
            EditorGUILayout.LabelField(string.Join(", ", SerializationManager.GetITypedSerializationSurrogateChildren()), this.textAreaStyle);
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.Space(8);
            EditorGUILayout.HelpBox("These are all classes that implement the interface ITypedSerializationSurrogate, a special interface used by this tool." +
                "\nIf you want to add additional serialization surrogates, create a class that implements ITypedSerializationSurrogate." +
                "\n\nCurrent Defaults: QuaternionSerializationSurrogate, Vector3SerializationSurrogate", MessageType.Info);
            GUILayout.Space(7);
            GUILayout.EndHorizontal();
            GUILayout.Space(7);
            if (this.folderError != null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(8);
                EditorGUILayout.HelpBox($"Save/Load Folder Path Error: {this.folderError}", MessageType.Error);
                GUILayout.Space(7);
                GUILayout.EndHorizontal();
                GUILayout.Space(7);
            }
            if (this.extensionError != null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(8);
                EditorGUILayout.HelpBox($"Extension Error: {this.extensionError}", MessageType.Error);
                GUILayout.Space(7);
                GUILayout.EndHorizontal();
                GUILayout.Space(7);
            }
            if (this.defaultNameError != null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(8);
                EditorGUILayout.HelpBox($"Default Save Name Error: {this.defaultNameError}", MessageType.Error);
                GUILayout.Space(7);
                GUILayout.EndHorizontal();
                GUILayout.Space(7);
            }
            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();
            GUILayout.Space(8);
            if (GUILayout.Button("Save", this.buttonStyle))
            {
                this.SavePreferenceChanges();
            }
            GUILayout.Space(7);
            GUILayout.EndHorizontal();
            GUILayout.Space(5);
            GUILayout.EndArea();
        }

        private void SavePreferenceChanges()
        {
            SaveLoadPreferences prefs = Resources.Load<SaveLoadPreferences>(Constants.SAVE_LOAD_PREFERENCES_FILENAME);
            SerializedObject so = new SerializedObject(prefs);

            this.folderError = prefs.VerifySaveFolder(this.folder);
            this.extensionError = prefs.VerifySaveExtension(this.extension);
            this.defaultNameError = prefs.VerifyDefaultSaveName(this.defaultName);

            if (folderError == null)
            {
                so.FindProperty("saveFolder").stringValue = this.folder;
            }
            if (extensionError == null)
            {
                so.FindProperty("saveExtension").stringValue = this.CheckExtension(this.extension);
                this.extension = so.FindProperty("saveExtension").stringValue;
            }
            if (defaultNameError == null)
            {
                so.FindProperty("defaultSaveName").stringValue = this.defaultName;
            }
            so.ApplyModifiedProperties();
        }

        private string CheckExtension(string checkExtension)
        {
            int checkPeriod = checkExtension.LastIndexOf('.');
            if (checkPeriod != -1)
            {
                if (checkExtension.Length <= 1)
                {
                    return "db";
                }
                return checkExtension.Substring(checkPeriod + 1);
            }
            return checkExtension;
        }
    }
}
