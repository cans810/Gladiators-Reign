using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHomeController : MonoBehaviour
{
    public GameObject playerPos;
    public GameObject glActionsTabPrefab;
    public int gladiatorSpacing;
    public GameObject selectedGladiator;
    public static string sceneMode;
    public static List<GameObject> selectedFighters = new List<GameObject>();
    public GameObject continueMultiFightButton;

    void Start()
    {
        continueMultiFightButton.SetActive(false);

        if (selectedFighters == null)
        {
            selectedFighters = new List<GameObject>();
        }

        float totalWidth = (GameManager.Instance.playerGLs.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            var gladiator = GameManager.Instance.playerGLs[i];
            adjustGladiatorTransform(gladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));

            var clickable = gladiator.GetComponent<ClickableObject>();
            if (clickable != null)
            {
                clickable.onClick.RemoveAllListeners(); // Clear any existing listeners

                if (sceneMode != null && sceneMode.Equals("MultiFight"))
                {
                    clickable.onClick.AddListener(() => OnClickSelectFighter(gladiator));
                }
                else
                {
                    clickable.onClick.AddListener(() => OnGladiatorClickActions(gladiator));
                }
            }

            if (gladiator.GetComponent<GLState>().isTraining)
            {
                adjustGladiatorTransform(gladiator, new Vector3(-100, -100, -100));
            }
            else if (gladiator.GetComponent<GLState>().waitingForLevelup)
            {
                gladiator.GetComponent<GladiatorManager>().gLEffectsManager.LeveledUpEffect();

                var clickable2 = gladiator.GetComponent<ClickableObject>();
                if (clickable2 != null)
                {
                    clickable2.onClick.RemoveAllListeners(); // Clear any existing listeners

                    if (sceneMode != null && sceneMode.Equals("MultiFight"))
                    {
                        clickable2.onClick.AddListener(() => OnClickSelectFighter(gladiator));
                    }
                    else
                    {
                        clickable2.onClick.AddListener(() => OnGladiatorClickLevelUpScene(gladiator));
                    }
                }
            }
        }

        if (sceneMode != null && sceneMode.Equals("MultiFight"))
        {
            MultiFightArrangerController.randomFighterAmount();
        }
    }

    void Update()
    {
        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            var gladiator = GameManager.Instance.playerGLs[i];

            if (gladiator.GetComponent<GLState>().waitingForLevelup && !gladiator.GetComponent<GLState>().levelUpHandled)
            {
                gladiator.GetComponent<GladiatorManager>().gLEffectsManager.LeveledUpEffect();

                var clickable2 = gladiator.GetComponent<ClickableObject>();
                if (clickable2 != null)
                {
                    clickable2.onClick.RemoveAllListeners(); // Clear any existing listeners

                    if (sceneMode != null && sceneMode.Equals("MultiFight"))
                    {
                        clickable2.onClick.AddListener(() => OnClickSelectFighter(gladiator));
                    }
                    else
                    {
                        clickable2.onClick.AddListener(() => OnGladiatorClickLevelUpScene(gladiator));
                        gladiator.GetComponent<GLState>().levelUpHandled = true;
                    }
                }
            }
        }

        if (sceneMode != null && sceneMode.Equals("MultiFight"))
        {
            if (MultiFightArrangerController.gladiatorAmount == selectedFighters.Count)
            {
                // ready to go, activate button
                continueMultiFightButton.SetActive(true);
            }
        }
    }

    public void GoToDungeonHallButton()
    {
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }

    public void adjustGladiatorTransform(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    public void OnGladiatorClickActions(GameObject gladiator)
    {
        if (selectedGladiator != null)
        {
            Destroy(GameObject.Find("GladiatorActionsTab(Clone)").gameObject);
        }

        Debug.Log("Gladiator clicked: " + gladiator.name);
        selectedGladiator = gladiator;
        selectedGladiator.GetComponent<GladiatorManager>().create_GLActionsTab();
    }

    public void OnGladiatorClickLevelUpScene(GameObject gladiator)
    {
        Debug.Log("Gladiator clicked: " + gladiator.name);
        LevelUpSceneManager.LeveledUp_Gl = gladiator;

        ScreenFadeController.Instance.FadeToScene("DungeonLevelUpScene");
    }

    public void OnClickSelectFighter(GameObject gladiator)
    {
        Debug.Log("Gladiator clicked: " + gladiator.name);
        selectedFighters.Add(gladiator);
    }

    public void GoToDungeonHallButton()
    {
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
