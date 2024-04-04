using UnityEngine;
using UnityEngine.Events;

public class ClickableObject : MonoBehaviour
{
    public UnityEvent onClick;

    // Called when the mouse is hovering over the object
    void OnMouseOver()
    {
    }

    // Called when the mouse is clicked on the object
    void OnMouseDown()
    {
        onClick.Invoke();
    }
}
