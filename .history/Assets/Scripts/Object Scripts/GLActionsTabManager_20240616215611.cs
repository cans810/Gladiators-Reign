using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GLActionsTabManager : MonoBehaviour
{
    public GameObject GLBelongTo;

    public GameObject GLName;

    public GameObject actionButtonPrefab;

    public GameObject gridLayout;


    // Start is called before the first frame update
    void Start()
    {
        GLName.GetComponent<TextMeshProUGUI>().text = GLBelongTo.GetComponent<GLAttributes>().gladiator_name;

        if (GLBelongTo.GetComponent<GLCommandsManager>().can_arrange_fight){
            GameObject actionButton = Instantiate(actionButtonPrefab);
            actionButton.transform.SetParent(gridLayout.transform);
            actionButton.transform.localScale = new Vector3(1, 1, 1);

            actionButton.GetComponent<Button>().onClick.AddListener(() => arrangeFight(GLBelongTo));
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_sendto_training){
            GameObject actionButton = Instantiate(actionButtonPrefab);
            actionButton.transform.SetParent(gridLayout.transform);
            actionButton.transform.localScale = new Vector3(1, 1, 1);
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_manage_equipment){
            GameObject actionButton = Instantiate(actionButtonPrefab);
            actionButton.transform.SetParent(gridLayout.transform);
            actionButton.transform.localScale = new Vector3(1, 1, 1);
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_manage_abilities){
            GameObject actionButton = Instantiate(actionButtonPrefab);
            actionButton.transform.SetParent(gridLayout.transform);
            actionButton.transform.localScale = new Vector3(1, 1, 1);
        }
        if (GLBelongTo.GetComponent<GLCommandsManager>().can_manage_magicskills){
            GameObject actionButton = Instantiate(actionButtonPrefab);
            actionButton.transform.SetParent(gridLayout.transform);
            actionButton.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void arrangeFight(GameObject gladiator){
        Debug.Log("fight arranged for gladiator " + gladiator.GetComponent<GLAttributes>().gladiator_name);
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
