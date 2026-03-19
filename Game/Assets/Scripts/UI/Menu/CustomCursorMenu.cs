using UnityEngine;

public class CustomCursorMenu : MonoBehaviour
{
    public Sprite cursorSprite;
    public float cursorSize = 64f;
    private Vector3 cursorOffset = Vector3.zero;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + cursorOffset;
        transform.position = cursorPosition;
    }

    private void OnGUI()
    {
        Rect cursorRect = new Rect(Event.current.mousePosition.x - cursorSize / 2, Event.current.mousePosition.y - cursorSize / 2, cursorSize, cursorSize);
        GUI.DrawTexture(cursorRect, cursorSprite.texture);
    }
}