using UnityEngine;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{    public UnityEvent onClick;

    void OnMouseDown()
    {
        // This is called when the mouse button is pressed over the object
        onClick.Invoke();
        Debug.Log("pressed");
    }
}
