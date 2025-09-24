using UnityEngine;

public class PreviewSpriteAttribute : PropertyAttribute {
    public float previewHeight;

    public PreviewSpriteAttribute(float height = 128f) {
        previewHeight = height;
    }
}