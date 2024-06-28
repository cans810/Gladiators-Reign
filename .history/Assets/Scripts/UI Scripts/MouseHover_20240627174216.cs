using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseHover : MonoBehaviour
{
    public UnityEvent onHover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter() {
        onHover.Invoke();
    }

    private void OnMouseExit() {
        
    }
}
