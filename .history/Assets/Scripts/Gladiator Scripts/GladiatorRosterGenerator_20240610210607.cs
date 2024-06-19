using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorRosterGenerator : MonoBehaviour
{
    public GameObject gladiatorPrefab;
    public Transform generatedGladiatorPosition;

    public List<GameObject> generatedGladiators;

    // Start is called before the first frame update
    void Start()
    {
        generatedGladiators = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GenerateRandomGladiatorRoster(int rosterSize){

        for (int i = 0; i<rosterSize ;i++){
            GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            setRandomRace();

            generatedGladiators.Add(generatedGladiator);
        }
        
    }

    public void setRandomRace(){
        int randomRace = Random.Range(0, generatedGladiator.GetComponent<AppereanceManager>().racesDict.Count);
        generatedGladiator.GetComponent<AppereanceManager>().currentRace = randomRace;

        int randomRegion = Random.Range(0, 3);
        generatedGladiator.GetComponent<AppereanceManager>().currentRegion = randomRegion;

        generatedGladiator.GetComponent<AppereanceManager>().setRace();
        generatedGladiator.GetComponent<AppereanceManager>().setRegion();


    }


}
