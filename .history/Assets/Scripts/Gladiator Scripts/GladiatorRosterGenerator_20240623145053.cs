using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorRosterGenerator : MonoBehaviour
{

    public FirstGladiatorSelectionManager manager;

    public GameObject gladiatorPrefab;
    public Transform initialGLPos;

    public List<GameObject> generatedGladiators;

    public GameObject glInfoTabPos;

    // Distance between each gladiator
    public float gladiatorSpacing = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GladiatorSelectionCanvas").GetComponent<FirstGladiatorSelectionManager>();

        generatedGladiators = new List<GameObject>();

        GenerateRandomGladiatorRoster(5);
    }

    public void GenerateRandomGladiatorRoster(int rosterSize)
    {
        float totalWidth = (rosterSize - 1) * gladiatorSpacing;
        Vector3 startPosition = initialGLPos.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < rosterSize; i++)
        {
            GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            setRandomRace(generatedGladiator);
            adjustGladiatorAfterSpawn(generatedGladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));

            generatedGladiator.GetComponent<ClickableObject>().onClick.RemoveAllListeners();
            generatedGladiator.GetComponent<ClickableObject>().onClick.AddListener(() => OnGladiatorClick(generatedGladiator));

            generatedGladiator.GetComponent<GLAttributes>().xp = 0;
            generatedGladiator.GetComponent <GLAttributes>().InitGladiator(1,1,1,1,1,1,1,1,1,1,0);

            generatedGladiators.Add(generatedGladiator);
        }
        
    }

    public void setRandomRace(GameObject gladiator)
    {
        int randomRace = Random.Range(0, gladiator.GetComponent<AppereanceManager>().racesDict.Count);
        gladiator.GetComponent<AppereanceManager>().currentRace = randomRace;

        gladiator.GetComponent<AppereanceManager>().setRace();
    }

    public void adjustGladiatorAfterSpawn(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    private void OnGladiatorClick(GameObject gladiator)
    {
        if (manager.selectedGladiator != null){
            Destroy(GameObject.Find("GladiatorInfoTab(Clone)").gameObject);
        }

        Debug.Log("Gladiator clicked: " + gladiator.name);    
        manager.selectedGladiator = gladiator;
        manager.selectedGladiator.GetComponent<GladiatorManager>().create_GLInfoTab();
        ma
    }

    public void goToDungeonsButton(){
        GameManager.Instance.playerGLs.Add(manager.selectedGladiator);

        foreach(GameObject generatedGl in generatedGladiators){
            if (generatedGl != manager.selectedGladiator){
                Destroy(generatedGl);
            }
        }

        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }
}
