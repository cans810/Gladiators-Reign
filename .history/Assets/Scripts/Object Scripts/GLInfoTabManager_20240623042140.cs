using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GLInfoTabManager : MonoBehaviour
{
    public GameObject GLBelongTo;

    public GameObject GLName;

    public TextMeshProUGUI atrb_Vitalis;
    public TextMeshProUGUI atrb_Vigor;
    public TextMeshProUGUI atrb_Resolve;
    public TextMeshProUGUI atrb_Vitalis;
    public TextMeshProUGUI atrb_Vitalis;
    public TextMeshProUGUI atrb_Vitalis;
    public TextMeshProUGUI atrb_Vitalis;
    public TextMeshProUGUI atrb_Vitalis;

    // Start is called before the first frame update
    void Start()
    {
        GLName.GetComponent<TextMeshProUGUI>().text = GLBelongTo.GetComponent<GLAttributes>().gladiator_name;
    }

    public void setPosition()
    {
        float yOffset = 8.0f;
        float xOffset = 0.05f;
        Vector3 newPosition = GLBelongTo.transform.position;
        newPosition.y += yOffset;
        newPosition.x -= xOffset;
        transform.position = newPosition;
    }
}
