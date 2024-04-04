using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
    public UnityEvent onClick;

    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Convert mouse position to 2D
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            // Check if the mouse position overlaps with the button's collider
            if (boxCollider.bounds.Contains(mousePosition2D))
            {
                // This is called when the button is clicked
                onClick.Invoke();
            }
        }
    }
}
