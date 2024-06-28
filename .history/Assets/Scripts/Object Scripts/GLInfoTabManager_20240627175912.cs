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

    public GameObject attributesTab;
    public GameObject seeAttributesButton;


    // Start is called before the first frame update
    void Start()
    {
        attributesTab.SetActive(false);
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

    public void seeAttributesHovered(){
        seeAttributesButton.GetComponent<TextMeshProUGUI>().color =  

        attributesTab.SetActive(true);

        atrb_Vitalis.text = GLBelongTo.GetComponent<GLAttributes>().Vitalis.ToString();
        atrb_Vigor.text = GLBelongTo.GetComponent<GLAttributes>().Vigor.ToString();
        atrb_Resolve.text = GLBelongTo.GetComponent<GLAttributes>().Resolve.ToString();
        atrb_Aetherius.text = GLBelongTo.GetComponent<GLAttributes>().Aetherius.ToString();
        atrb_Celerity.text = GLBelongTo.GetComponent<GLAttributes>().Celerity.ToString();
        atrb_Ferocity.text = GLBelongTo.GetComponent<GLAttributes>().Ferocity.ToString();
        atrb_Insight.text = GLBelongTo.GetComponent<GLAttributes>().Insight.ToString();
        atrb_Fortitude.text = GLBelongTo.GetComponent<GLAttributes>().Fortitude.ToString();
        atrb_Harmony.text = GLBelongTo.GetComponent<GLAttributes>().Harmony.ToString();
        atrb_ArcaneMastery.text = GLBelongTo.GetComponent<GLAttributes>().ArcaneMastery.ToString();
    }

    public void seeAttributesHoverExit(){
        attributesTab.SetActive(false);
    }
}
