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
        GLName.GetComponent<TextMeshProUGUI>().text = GLBelongTo.GetComponent<GLAttributes>().gladiator_name;
    }

    public void setPosition()
    {
        float yOffset = 5.0f;
        Vector3 newPosition = GLBelongTo.transform.position;
        newPosition.y += yOffset;
        transform.position = newPosition;
    }
}
