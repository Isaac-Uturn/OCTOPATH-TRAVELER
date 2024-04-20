using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tools
{
    public class IconGroup
    {
        public string name;
        public GUIStyle[] iconData;
        public float iconWidthThreshold;
        public float maxWidth;
    }

    public class MapToolWindow : EditorWindow
    {
        public List<IconGroup> iconGroups;
        public static float[] kIconThresholds = { 0, 9, 25, 35, 100, 99999 };

        public static float kSidePanelMinWidth = 150;
        public static float kSidePanelMaxWidth = 250;
        public static float kScrollbarWidth = 15;
        public static float kSelectionGridPadding = 10;

        protected GUISkin editorSkin;
        protected GUIStyle selectedIcon;
        protected Vector2 scrollPos;
        protected float drawScale;

        private List<GameObject> prefabs = new List<GameObject>();

        int selectIndex = -1;

        int xPos = 0;
        int yPos = 0;
        
        [MenuItem("Tools/Map Tool")]
        static void Init()
        {
            MapToolWindow window = (MapToolWindow)GetWindow(typeof(MapToolWindow), false, "Map Tool");
            window.position = new Rect(150, 150, 700, 400);
        }

        void OnEnable()
        {
            editorSkin = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector);
            scrollPos = Vector2.zero;
            
            iconGroups = new List<IconGroup>();

            //get tiles
            string prefabFolderPath = "Assets/Resources/Prefab/Tiles";
            string[] prefabPaths = AssetDatabase.FindAssets("t:Prefab", new[] { prefabFolderPath })
                                                    .Select(AssetDatabase.GUIDToAssetPath)
                                                    .ToArray();

            List<GUIStyle> iconData = new List<GUIStyle>();

            foreach (string prefabPath in prefabPaths)
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                Texture2D preview = AssetPreview.GetAssetPreview(prefab);

                if (preview != null)
                {
                    iconData.Add(new GUIStyle { normal = new GUIStyleState { background = preview } });
                }

                prefabs.Add(prefab);
            }

            IconGroup group = new IconGroup();
            group.name = "Tiles";
            group.iconData = iconData.ToArray();

            float maxWidth = 0;
            foreach (GUIStyle style in group.iconData)
            {
                maxWidth = (style.normal.background.width > maxWidth) ? style.normal.background.width : maxWidth;
            }
            group.maxWidth = maxWidth;

            iconGroups.Add(group);

            SceneView.duringSceneGui -= OnSceneGUI;
            SceneView.duringSceneGui += OnSceneGUI;
        }

        private void OnDisable()
        {
            SceneView.duringSceneGui -= OnSceneGUI;
        }

        private void OnSceneGUI(SceneView obj)
        {
            Vector2 mousePos = Event.current.mousePosition;
            //get mouse point
            Ray ray = HandleUtility.GUIPointToWorldRay(mousePos);

            Vector3 rayDestPos = ray.origin;
            Vector3 rayOriPos = ray.origin + ray.direction /** 300*/;

            Vector3 planePos1 = Vector3.up;
            Vector3 planePos2 = Vector3.right;
            Vector3 planePos3 = Vector3.down;

            Vector3 planeDir = Vector3.Cross((planePos2 - planePos1).normalized, (planePos3 - planePos1).normalized);
            Vector3 lineDir = (rayDestPos - rayOriPos).normalized;

            float dotLinePlane = Vector3.Dot(lineDir, planeDir);
            float t = Vector3.Dot(planePos1 - rayOriPos, planeDir) / dotLinePlane;

            Vector3 hitPos = rayOriPos + (lineDir * t);

            Debug.Log(hitPos);

            //Create tile
            if (0 == Event.current.button
                && Event.current.type == EventType.MouseDown)
            {
                GameObject tile = Instantiate(prefabs[selectIndex]);
                tile.transform.position = hitPos;
            }
        }

        void OnGUI()
        {
            float sidePanelWidth = CalculateSidePanelWidth();
            GUILayout.BeginArea(new Rect(0, 0, sidePanelWidth, position.height), GUI.skin.box);
            DrawIconDisplay(selectedIcon);
            GUILayout.EndArea();

            GUI.BeginGroup(new Rect(sidePanelWidth, 0, position.width - sidePanelWidth, position.height));
            scrollPos = GUILayout.BeginScrollView(scrollPos, true, true, GUILayout.MaxWidth(position.width - sidePanelWidth));

            for (int i = 0; i < iconGroups.Count; ++i)
            {
                IconGroup group = iconGroups[i];
                EditorGUILayout.LabelField(group.name);
                DrawIconSelectionGrid(group.iconData, group.maxWidth);

                GUILayout.Space(15);
            }

            GUILayout.EndScrollView();
            GUI.EndGroup();
        }

        protected float CalculateSidePanelWidth()
        {
            return Mathf.Clamp(position.width * 0.21f, kSidePanelMinWidth, kSidePanelMaxWidth);
        }

        protected void DrawIconDisplay(GUIStyle style)
        {
            if (null == style)
            {
                DrawCenteredMessage("No icon selected");
                GUILayout.FlexibleSpace();
                return;
            }

            Texture2D iconTexture = style.normal.background;

            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(style.name, EditorStyles.whiteLargeLabel);
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label("Preview");
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            //GUILayout.FlexibleSpace();
            //EditorGUILayout.LabelField("Name: {0}", prefabs[selectIndex].name);
            //GUILayout.FlexibleSpace();

            float iconOffset = 45;
            float iconWidth = iconTexture.width * drawScale;
            float iconHeight = iconTexture.height * drawScale;
            float sidePanelWidth = CalculateSidePanelWidth();
            GUI.DrawTexture(new Rect((sidePanelWidth - iconWidth) * 0.5f, iconOffset, iconWidth, iconHeight), iconTexture, ScaleMode.StretchToFill);

            GUILayout.Space(iconHeight + 10);

            EditorGUILayout.LabelField(string.Format("Width:      {0}px", iconTexture.width));
            EditorGUILayout.LabelField(string.Format("Height:    {0}px", iconTexture.height));

            GUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Toggle(drawScale == 1.0f, "1x", EditorStyles.miniButtonLeft))
            {
                drawScale = 1.0f;
            }

            if (GUILayout.Toggle(drawScale == 1.5f, "1.5x", EditorStyles.miniButtonMid))
            {
                drawScale = 1.5f;
            }

            if (GUILayout.Toggle(drawScale == 2.0f, "2x", EditorStyles.miniButtonRight))
            {
                drawScale = 2.0f;
            }

            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);

            xPos = EditorGUILayout.IntField("Cell X", xPos);
            yPos = EditorGUILayout.IntField("Cell Y", yPos);
            GUILayout.FlexibleSpace();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Create", GUILayout.Width(120), GUILayout.Height(30)))
            {
                Instantiate<GameObject>(prefabs[selectIndex]);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        protected void DrawIconStyleState(GUIStyleState state, string label)
        {
            if (null == state
                || null == state.background)
            {
                return;
            }

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(label);
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Box(state.background);
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        protected void SetSelectedIcon(GUIStyle[] icons, int index)
        {
            selectedIcon = icons[index];
            selectIndex = index;
            drawScale = 1.0f;
        }

        protected void DrawIconSelectionGrid(GUIStyle[] icons, float maxIconWidth)
        {
            float sidePanelWidth = CalculateSidePanelWidth();
            int xCount = Mathf.FloorToInt((position.width - sidePanelWidth - kScrollbarWidth) / (maxIconWidth + kSelectionGridPadding));
            int selected = GUILayout.SelectionGrid(-1, icons.Select(style => style.normal.background).ToArray(), xCount, GUI.skin.box);

            if (-1 < selected)
            {
                SetSelectedIcon(icons, selected);
            }
        }

        protected void DrawCenteredMessage(string msg)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            EditorGUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            GUILayout.Label(msg);
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndVertical();
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }
    }
}
