using UnityEditor;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class OpenSelectedInk
{
    [MenuItem("AlmejaTools/Open Selected Ink File")]
    public static void OpenSelectedInkFile()
    {
        Object selected = Selection.activeObject;

        if (selected == null)
        {
            UnityEngine.Debug.LogWarning("⚠️ No hay ningún archivo seleccionado.");
            return;
        }

        string assetPath = AssetDatabase.GetAssetPath(selected);

        if (!assetPath.EndsWith(".ink"))
        {
            UnityEngine.Debug.LogWarning($"⚠️ El archivo seleccionado no es un .ink: {assetPath}");
            return;
        }

        string fullPath = Path.GetFullPath(assetPath);
        string inkyPath = @"E:\Inky_windows_64\Inky.exe"; // ← Ajusta esta ruta si cambia

        if (!File.Exists(inkyPath))
        {
            UnityEngine.Debug.LogError($"❌ No se encontró Inky en: {inkyPath}");
            return;
        }

        Process.Start(new ProcessStartInfo
        {
            FileName = inkyPath,
            Arguments = $"\"{fullPath}\"",
            UseShellExecute = true
        });

        UnityEngine.Debug.Log($"✅ Abriendo {selected.name} en Inky...");
    }
}