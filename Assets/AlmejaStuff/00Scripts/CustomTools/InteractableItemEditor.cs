#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InteractableItem))]
public class InteractableItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InteractableItem item = (InteractableItem)target;

        if (item.ItemData == null)
        {
            EditorGUILayout.HelpBox("ItemData is null", MessageType.Error);
            DrawDefaultInspector();
            return;
        }
        EditorGUILayout.LabelField("🧠 Estado actual de interacción", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Item:", item.ItemData.ItemName);
        EditorGUILayout.LabelField("Collectible:", item.ItemData.IsCollectable.ToString());
        EditorGUILayout.LabelField("Draggable:", item.ItemData.IsDraggable.ToString());
        EditorGUILayout.LabelField("TriggersAction:", item.ItemData.TriggerAction.ToString());
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("🎛️ Cambiar tipo de interacción:");
        item.ItemData.CurrentInteractionType = (InteractionType)EditorGUILayout.EnumPopup("Tipo", item.ItemData.CurrentInteractionType);

        if (GUILayout.Button("Aplicar tipo"))
        {
            item.ItemData.SetInteractionType(item.ItemData.CurrentInteractionType);
            EditorUtility.SetDirty(item.ItemData);
        }
        EditorGUILayout.Space();
        DrawDefaultInspector();
    }
}
#endif
