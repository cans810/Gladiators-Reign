using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHomeController : MonoBehaviour
{
    public GameObject playerPos;

    public GameObject glActionsTabPrefab;

    public int gladiatorSpacing;

    public GameObject selectedGladiator;

    // Start is called before the first frame update
    void Start()
    {
        var playerGLs = GameManager.Instance.playerGLs;

        if (playerGLs == null || playerGLs.Count == 0)
        {
            Debug.LogError("Player gladiators list is null or empty.");
            return;
        }

        float totalWidth = (playerGLs.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < playerGLs.Count; i++)
        {
            if (i >= playerGLs.Count)
            {
                Debug.LogError($"Index {i} is out of range for player gladiators list.");
                continue;
            }

            var gladiator = playerGLs[i];
            adjustGladiatorTransform(gladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));

            var clickable = gladiator.GetComponent<ClickableObject>();
            if (clickable != null)
            {
                clickable.onClick.RemoveAllListeners();  // Clear any existing listeners

                // Capture the current gladiator in the loop to avoid closure issues
                clickable.onClick.AddListener(() => OnGladiatorClickActions(gladiator));
            }
            else
            {
                Debug.LogError($"ClickableObject component is missing on gladiator at index {i}.");
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToDungeonHallButton(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }

    public void adjustGladiatorTransform(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    public void OnGladiatorClickActions(GameObject gladiator){
        if (selectedGladiator != null){
            Destroy(GameObject.Find("GladiatorActionsTab(Clone)").gameObject);
        }

        Debug.Log("Gladiator clicked: " + gladiator.name);    
        selectedGladiator = gladiator;
        selectedGladiator.GetComponent<GladiatorManager>().create_GLActionsTab();
    }
}
