using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GLActionsTabManager : MonoBehaviour
{
    public GameObject GLBelongTo;

    public GameObject GLName;

    public GameObject actionButtonPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GLName.GetComponent<TextMeshProUGUI>().text = GLBelongTo.GetComponent<GLAttributes>().gladiator_name;

        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){

        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){
            
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){
            
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){
            
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){
            
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){
            
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){
            
        }
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
