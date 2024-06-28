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

    void OnMouseDown()
    {
        onClick.Invoke();
        animator.SetBool("Clicked",true);
    }

    public void stopAnim(){
        animator.SetBool("Clicked",true);
    }
}
