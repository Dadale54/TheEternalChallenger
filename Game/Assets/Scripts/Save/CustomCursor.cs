using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Le sprite à utiliser pour le curseur personnalisé.
    public Sprite cursorSprite;
    private Sprite saveCursor;

    // La taille du curseur personnalisé.
    public float cursorSize = 64f;

    // Un offset pour ajuster la position du curseur par rapport à la position de la souris.
    public Vector3 cursorOffset = Vector3.zero;

    private void Start()
    {
        // Masquer le curseur par défaut.
        Cursor.visible = false;

        saveCursor = cursorSprite;

        // Bloquer le curseur dans la fenêtre du jeu.
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        // Mettre à jour la position du curseur personnalisé pour suivre la souris.
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + cursorOffset;
        transform.position = cursorPosition;

        // Gérer l'affichage du curseur en fonction de Time.timeScale
        if (Time.timeScale == 1)
        {
            Hide();
        }
        else if (Time.timeScale == 0)
        {
            Show();
        }
    }

    private void OnGUI()
    {
        // Dessiner le curseur personnalisé seulement s'il y a un sprite.
        if (cursorSprite != null)
        {
            Rect cursorRect = new Rect(Event.current.mousePosition.x - cursorSize / 2, Event.current.mousePosition.y - cursorSize / 2, cursorSize, cursorSize);
            GUI.DrawTexture(cursorRect, cursorSprite.texture);
        }
    }

    // Méthode pour masquer le curseur
    public void Hide()
    {
        cursorSprite = null;
    }

    // Méthode pour afficher le curseur
    public void Show()
    {
        cursorSprite = saveCursor;
    }
}