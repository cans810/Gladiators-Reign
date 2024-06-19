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

    public GameObject equipmentCanvas;


    // Start is called before the first frame update
    void Start()
    {
        GameObject equipmentCanvas = GameObject.Find("EquipmentCanvas");

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

            actionButton.GetComponent<Button>().onClick.AddListener(() => manageEquipment(GLBelongTo));
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
        ScreenFadeController.Instance.FadeToScene("DungeonBattleArrangerScene");
    }

    public void manageEquipment(GameObject gladiator){
        GameObject equipmentCanvas = GameObject.Find("EquipmentCanvas");

        equipmentCanvas.SetActive(true);

        equipmentCanvas.GetComponent<PlayerEquipmentCanvas>().showInventory(gladiator);
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
