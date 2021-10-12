//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//namespace EditorExample
//{
//    public class WindowExample : EditorWindow
//    {
//        private Texture2D headerTexture;
//        private Texture2D hazardTexture;
//        private Texture2D encounterTexture;
//        private Texture2D effectTexture;

//        private Color headerColor = new Color(100f / 255f, 100f / 255f, 100f / 255f, 1f);
//        private Color hazardColor = new Color(50f / 255f, 100f / 255f, 100f / 255f, 1f);
//        private Color encounterColor = new Color(100f / 255f, 50f / 255f, 100f / 255f, 1f);
//        private Color effectColor = new Color(100f / 255f, 100f / 255f, 50f / 255f, 1f);

//        private Rect headerSection;
//        private Rect hazardSection;
//        private Rect encounterSection;
//        private Rect effectSection;

//        private HazardData hazardData;
//        private EncounterData encounterData;
//        private EffectData effectData;

//        public HazardData HazardInfo { get { return this.hazardData; } }
//        public EncounterData EncounterInfo { get { return this.encounterData; } }
//        public EffectData EffectInfo { get { return this.effectData; } }

//        [MenuItem("Window/Example Window")]
//        static void OpenWindow()
//        {
//            WindowExample window = GetWindow<WindowExample>();
//            window.minSize = new Vector2(600, 300);
//            window.maxSize = new Vector2(900, 450);
//            window.Show();
//        }

//        private void OnEnable()
//        {
//            this.InitTextures();
//            this.InitData();
//        }

//        private void InitData()
//        {
//            this.hazardData = ScriptableObject.CreateInstance<HazardData>();
//            this.encounterData = ScriptableObject.CreateInstance<EncounterData>();
//            this.effectData = ScriptableObject.CreateInstance<EffectData>();
//        }

//        private void InitTextures()
//        {
//            this.headerTexture = new Texture2D(1, 1);
//            this.headerTexture.SetPixel(0, 0, headerColor);
//            this.headerTexture.Apply();

//            this.hazardTexture = new Texture2D(1, 1);
//            this.hazardTexture.SetPixel(0, 0, hazardColor);
//            this.hazardTexture.Apply();

//            this.encounterTexture = new Texture2D(1, 1);
//            this.encounterTexture.SetPixel(0, 0, encounterColor);
//            this.encounterTexture.Apply();

//            this.effectTexture = new Texture2D(1, 1);
//            this.effectTexture.SetPixel(0, 0, effectColor);
//            this.effectTexture.Apply();

//        }

//        private void OnGUI()
//        {
//            this.DrawLayouts();
//            this.DrawHeader();
//            this.DrawHazardSettings();
//            this.DrawEncounterSettings();
//            this.DrawEffectSettings();
//        }

//        private void DrawLayouts()
//        {
//            this.headerSection.x = 0;
//            this.headerSection.y = 0;
//            this.headerSection.width = position.width;
//            this.headerSection.height = 30;

//            GUI.DrawTexture(this.headerSection, this.headerTexture);

//            this.hazardSection.x = 0;
//            this.hazardSection.y = 30;
//            this.hazardSection.width = position.width / 3f;
//            this.hazardSection.height = position.height - 30;

//            GUI.DrawTexture(this.hazardSection, this.hazardTexture);

//            this.encounterSection.x = position.width / 3f;
//            this.encounterSection.y = 30;
//            this.encounterSection.width = position.width / 3f;
//            this.encounterSection.height = position.height - 30;

//            GUI.DrawTexture(this.encounterSection, this.encounterTexture);

//            this.effectSection.x = position.width / 3f * 2f;
//            this.effectSection.y = 30;
//            this.effectSection.width = position.width / 3f;
//            this.effectSection.height = position.height - 30;

//            GUI.DrawTexture(this.effectSection, this.effectTexture);
//        }

//        private void DrawHeader()
//        {
//            GUILayout.BeginArea(this.headerSection);

//            GUILayout.Label("Event Creator");

//            GUILayout.EndArea();
//        }

//        private void DrawHazardSettings()
//        {
//            GUILayout.BeginArea(this.hazardSection);

//            GUILayout.Label("Hazard");

//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Label("Damage Type");
//            this.hazardData.damageType = (Types.HazardDamageType)EditorGUILayout.EnumPopup(this.hazardData.damageType);
//            EditorGUILayout.EndHorizontal();

//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Label("Activation Type");
//            this.hazardData.activationType = (Types.HazardActivationType)EditorGUILayout.EnumPopup(this.hazardData.activationType);
//            EditorGUILayout.EndHorizontal();

//            if (GUILayout.Button("Create", GUILayout.Height(40)))
//            {
//                GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Hazard, this);
//            }

//            GUILayout.EndArea();
//        }

//        private void DrawEncounterSettings()
//        {
//            GUILayout.BeginArea(this.encounterSection);

//            GUILayout.Label("Encounter");

//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Label("Difficulty");
//            this.encounterData.difficulty = (Types.EncounterDifficulty)EditorGUILayout.EnumPopup(this.encounterData.difficulty);
//            EditorGUILayout.EndHorizontal();

//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Label("Encounter Style");
//            this.encounterData.style = (Types.EncounterStyleType)EditorGUILayout.EnumPopup(this.encounterData.style);
//            EditorGUILayout.EndHorizontal();

//            if (GUILayout.Button("Create", GUILayout.Height(40)))
//            {
//                GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Encounter, this);
//            }

//            GUILayout.EndArea();
//        }

//        private void DrawEffectSettings()
//        {
//            GUILayout.BeginArea(this.effectSection);

//            GUILayout.Label("Effect");

//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Label("Effect Type");
//            this.effectData.type = (Types.EffectType)EditorGUILayout.EnumPopup(this.effectData.type);
//            EditorGUILayout.EndHorizontal();

//            EditorGUILayout.BeginHorizontal();
//            GUILayout.Label("Effect Time Type");
//            this.effectData.timeType = (Types.EffectTimeType)EditorGUILayout.EnumPopup(this.effectData.timeType);
//            EditorGUILayout.EndHorizontal();

//            if (GUILayout.Button("Create", GUILayout.Height(40)))
//            {
//                GeneralSettings.OpenWindow(GeneralSettings.SettingsType.Effect, this);
//            }

//            GUILayout.EndArea();
//        }
//    }

//    public class GeneralSettings : EditorWindow
//    {
//        public enum SettingsType
//        {
//            Hazard,
//            Encounter,
//            Effect
//        }
//        private SettingsType dataSetting;
//        private WindowExample parent;
//        static GeneralSettings window;

//        public static void OpenWindow(SettingsType setting, WindowExample parent)
//        {
//            window = GetWindow<GeneralSettings>();
//            window.dataSetting = setting;
//            window.parent = parent;
//            window.minSize = new Vector2(250, 200);
//            window.maxSize = new Vector2(500, 400);
//            window.Show();
//        }

//        private void OnGUI()
//        {
//            switch(this.dataSetting)
//            {
//                case SettingsType.Hazard: this.DrawHazard(); break;
//                case SettingsType.Encounter: this.DrawEncounter(); break;
//                case SettingsType.Effect: this.DrawEffect(); break;
//                default: this.DrawHazard(); break;
//            }
//        }

//        private void DrawHazard()
//        {

//        }

//        private void DrawEncounter()
//        {

//        }

//        private void DrawEffect()
//        {

//        }
//    }
//}

