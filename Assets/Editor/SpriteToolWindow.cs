using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEditor;
using UnityEngine;

public class SpriteToolWindow : EditorWindow
{
    public Texture2D texture;
    private Vector2 pivot = new Vector2(0.5f, 0.5f);

    [MenuItem("Tools/Sprite Tool")]
    static void Init()
    {
        SpriteToolWindow window = (SpriteToolWindow)GetWindow(typeof(SpriteToolWindow), false, "Sprite Tool");
        window.position = new Rect(150, 150, 700, 400);
    }

    void OnGUI()
    {
        GUILayout.Label("Texture", EditorStyles.boldLabel);
        texture = EditorGUILayout.ObjectField(texture, typeof(Texture2D), false) as Texture2D;

        GUILayout.Label("Pivot", EditorStyles.boldLabel);
        pivot = EditorGUILayout.Vector2Field("", pivot);

        if (GUILayout.Button("Test", GUILayout.Width(120), GUILayout.Height(30)))
        {
            string path = AssetDatabase.GetAssetPath(texture);
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            TextureImporterSettings texSettings = new TextureImporterSettings();

            textureImporter.ReadTextureSettings(texSettings);
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            texSettings.spriteAlignment = (int)SpriteAlignment.Custom;
            textureImporter.spritePivot = pivot;

            textureImporter.SetTextureSettings(texSettings);
            textureImporter.SaveAndReimport();

            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
            AssetDatabase.WriteImportSettingsIfDirty(path);
        }
    }
}
