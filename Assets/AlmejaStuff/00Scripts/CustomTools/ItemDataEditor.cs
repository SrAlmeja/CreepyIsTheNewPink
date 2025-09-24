using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemData))]
public class ItemDataEditor : Editor {
    public override void OnInspectorGUI() {
        ItemData item = (ItemData)target;

        // Mostrar el campo por defecto
        DrawDefaultInspector();

        // Mostrar el Sprite en grande
        if (item.ItemSprite != null) {
            GUILayout.Space(10);
            GUILayout.Label("Vista previa del Sprite", EditorStyles.boldLabel);

            Texture2D tex = AssetPreview.GetAssetPreview(item.ItemSprite);
            if (tex != null) {
                float size = 128f;
                Rect rect = GUILayoutUtility.GetRect(size, size, GUILayout.ExpandWidth(false));
                GUI.DrawTexture(rect, tex, ScaleMode.ScaleToFit);
            }
        }
    }
}
