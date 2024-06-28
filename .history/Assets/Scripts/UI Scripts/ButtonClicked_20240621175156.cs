using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonClicked : MonoBehaviour
{
    Animator animator;

    public UnityEvent onClick;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (isClickable){
            onClick.Invoke();
        }
    }
}
