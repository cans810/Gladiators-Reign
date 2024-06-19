using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GLInfoTabManager : MonoBehaviour
{
    public GameManager GLBelongTo;

    public GameObject GLName;

    // Start is called before the first frame update
    void Start()
    {
        GLName.GetComponent<TextMeshProUGUI>() = GLBelongTo.GetComponent<GLAttributes>().gladiator_name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
