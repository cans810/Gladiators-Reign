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
    public TextMeshProUGUI atrb_Aetherius;
    public TextMeshProUGUI atrb_Celerity;
    public TextMeshProUGUI atrb_Ferocity;
    public TextMeshProUGUI atrb_Insight;
    public TextMeshProUGUI atrb_Fortitude;
    public TextMeshProUGUI atrb_Harmony;
    public TextMeshProUGUI atrb_ArcaneMastery;

    // Start is called before the first frame update
    void Start()
    {
        GLName.GetComponent<TextMeshProUGUI>().text = GLBelongTo.GetComponent<GLAttributes>().gladiator_name;

        atrb_Vitalis.text = GLBelongTo.GetComponent<GLAttributes>().Vitalis.ToString();
        atrb_Vigor.text = GLBelongTo.GetComponent<GLAttributes>().Vigor.ToString();
        atrb_Resolve.text = GLBelongTo.GetComponent<GLAttributes>().Resolve.ToString();
        atrb_Aetherius.text = GLBelongTo.GetComponent<GLAttributes>().Vitalis.ToString();
        atrb_Celerity.text = GLBelongTo.GetComponent<GLAttributes>().Vitalis.ToString();
        atrb_Ferocity.text = GLBelongTo.GetComponent<GLAttributes>().Vitalis.ToString();
        atrb_Insight.text = GLBelongTo.GetComponent<GLAttributes>().Vitalis.ToString();
        atrb_Fortitude.text = GLBelongTo.GetComponent<GLAttributes>().Vitalis.ToString();
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
