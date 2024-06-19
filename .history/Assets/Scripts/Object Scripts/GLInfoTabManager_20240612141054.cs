using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLInfoTabManager : MonoBehaviour
{
    public GameManager GLBelongTo;

    public GameObject GLName;

    // Start is called before the first frame update
    void Start()
    {
        GLName = GLBelongTo.GetComponent<GLAttributes>()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
