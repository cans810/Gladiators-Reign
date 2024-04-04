using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Called when the mouse is hovering over the object
    void OnMouseOver()
    {
        // Do something when the mouse is hovering over the object
        Debug.Log("Mouse is hovering over the object");
    }

    // Called when the mouse is clicked on the object
    void OnMouseDown()
    {
        // Do something when the mouse is clicked on the object
        Debug.Log("Mouse clicked on the object");
    }
}
