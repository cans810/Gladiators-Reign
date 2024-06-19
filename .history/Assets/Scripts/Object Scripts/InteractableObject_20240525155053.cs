using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent onInteract;

    // Start is called before the first frame update
    void Start()
    {
        if (onInteract == null)
        {
            onInteract = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // For demonstration purposes, let's trigger the interaction with a key press
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (onInteract != null)
        {
            onInteract.Invoke();
        }
    }
}
