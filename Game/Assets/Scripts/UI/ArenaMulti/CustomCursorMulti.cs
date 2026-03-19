using UnityEngine;

public class CustomCursorMulti : MonoBehaviour
{
    [SerializeField] private Sprite cursorSprite;
    [SerializeField] private float cursorSize = 64f;
    [SerializeField] private Vector3 cursorOffset = Vector3.zero;

    private Sprite saveCursor;

    private void Start()
    {
        Cursor.visible = false;
        saveCursor = cursorSprite;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + cursorOffset;
        transform.position = cursorPosition;

        if (Time.timeScale == 1)
        {
            cursorSprite = null;
        }
        else if (Time.timeScale == 0)
        {
            cursorSprite = saveCursor;
        }
    }

    private void OnGUI()
    {
        if (cursorSprite != null)
        {
            Rect cursorRect = new Rect(Event.current.mousePosition.x - cursorSize / 2, Event.current.mousePosition.y - cursorSize / 2, cursorSize, cursorSize);
            GUI.DrawTexture(cursorRect, cursorSprite.texture);
        }
    }
}