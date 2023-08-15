using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorImage;
    private void Start()
    {
        Vector2 hotSpot = new Vector2(cursorImage.width / 2, cursorImage.height / 2);
        Cursor.SetCursor(cursorImage, hotSpot, CursorMode.ForceSoftware);
    }
}
