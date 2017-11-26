using UnityEngine;
using UnityEditor;

public class MakeScriptableObject
{
    [MenuItem("Assets/Create/Paca Scriptable Object")]
    public static void CreateMyAsset()
    {
        Paca asset = ScriptableObject.CreateInstance<Paca>();

        AssetDatabase.CreateAsset(asset, "Assets/Paca.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}