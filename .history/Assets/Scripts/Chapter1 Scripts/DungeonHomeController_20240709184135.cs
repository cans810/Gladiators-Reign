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
        float totalWidth = (GameManager.Instance.playerGLs.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            if (i >= GameManager.Instance.playerGLs.Count)
            {
                continue;
            }

            var gladiator = GameManager.Instance.playerGLs[i];
            adjustGladiatorTransform(gladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));

            var clickable = gladiator.GetComponent<ClickableObject>();
            if (clickable != null)
            {
                clickable.onClick.RemoveAllListeners();  // Clear any existing listeners

                clickable.onClick.AddListener(() => OnGladiatorClickActions(gladiator));
            }

            if (gladiator.GetComponent<GLState>().isTraining){
                adjustGladiatorTransform(gladiator, new Vector3(-100,-100,-100));
            }
            else if (gladiator.GetComponent<GLState>().waitingForLevelup){
                gladiator.GetComponent<GladiatorManager>().gLEffectsManager.LeveledUpEffect();

                
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
