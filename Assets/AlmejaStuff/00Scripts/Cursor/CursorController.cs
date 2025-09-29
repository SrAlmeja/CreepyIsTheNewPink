using System;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    #region Variables
    [Header("Cursor")]
    [SerializeField] private Texture2D cursorTexture;
    //[SerializeField] private Texture2D interactionCursorTexture;
    [SerializeField] private Vector2 hotSpot = Vector2.zero;
    #endregion

    private void Start()
    {
        SetDefaultCursor();
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
    /*
    public void SetInteractionCursor()
    {
        Cursor.SetCursor(interactionCursorTexture, hotSpot, CursorMode.Auto);
    }*/
}
