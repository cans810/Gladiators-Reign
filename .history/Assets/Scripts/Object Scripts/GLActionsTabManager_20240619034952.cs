using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        GameObject equipmentCanvas = FindInactiveObjectByName("EquipmentCanvas");

        GameObject gladiatorModel = Instantiate(gladiator);

        Component[] components = obj.GetComponents<Component>();

        foreach (Component component in components)
        {
            if (component is MonoBehaviour && !(component is Transform))
            {
                Destroy(component);
            }
        }

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

    public GameObject FindInactiveObjectByName(string name)
    {
        Scene activeScene = SceneManager.GetActiveScene();
        GameObject[] rootObjects = activeScene.GetRootGameObjects();

        foreach (GameObject rootObject in rootObjects)
        {
            GameObject foundObject = FindInactiveObjectInChildren(rootObject, name);
            if (foundObject != null)
            {
                return foundObject;
            }
        }
        return null;
    }

    private GameObject FindInactiveObjectInChildren(GameObject parent, string name)
    {
        if (parent.name == name)
        {
            return parent;
        }

        foreach (Transform child in parent.transform)
        {
            GameObject foundObject = FindInactiveObjectInChildren(child.gameObject, name);
            if (foundObject != null)
            {
                return foundObject;
            }
        }

        return null;
    }
}
