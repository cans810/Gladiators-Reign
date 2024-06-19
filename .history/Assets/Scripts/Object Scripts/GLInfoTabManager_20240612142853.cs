using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GLInfoTabManager : MonoBehaviour
{
    public GameObject GLBelongTo;

    public GameObject GLName;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = GLBelongTo.transform.localPosition;

        GLName.GetComponent<TextMeshProUGUI>().text = GLBelongTo.GetComponent<GLAttributes>().gladiator_name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
