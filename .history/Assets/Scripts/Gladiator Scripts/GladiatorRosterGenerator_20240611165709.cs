using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorRosterGenerator : MonoBehaviour
{
    public GameObject gladiatorPrefab;
    public Transform initialGLPos;

    public List<GameObject> generatedGladiators;

    public Material outlineMaterial;

    public GameObject selectedGladiator;


    // Distance between each gladiator
    public float gladiatorSpacing = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        generatedGladiators = new List<GameObject>();

        GenerateRandomGladiatorRoster(5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GenerateRandomGladiatorRoster(int rosterSize)
    {
        float totalWidth = (rosterSize - 1) * gladiatorSpacing;
        Vector3 startPosition = initialGLPos.position - new Vector3(totalWidth / 2, 0, 0);

        for (int i = 0; i < rosterSize; i++)
        {
            GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            setRandomRace(generatedGladiator);
            adjustGladiatorAfterSpawn(generatedGladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));


            generatedGladiator.GetComponent<ClickableObject>().onClick.AddListener(() => OnGladiatorClick(generatedGladiator));

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
        gladiator.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    private void OnGladiatorClick(GameObject gladiator)
    {
        Debug.Log("Gladiator clicked: " + gladiator.name);    
        selectedGladiator = gladiator;
    }

    public void goToDungeonsButton(){
        GameManager.Instance.playerGLs.Add(selectedGladiator);

        foreach

        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
