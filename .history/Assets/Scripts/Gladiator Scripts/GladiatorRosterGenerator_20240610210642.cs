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

        GenerateRandomGladiatorRoster()

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GenerateRandomGladiatorRoster(int rosterSize){

        for (int i = 0; i<rosterSize ;i++){
            GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            setRandomRace(generatedGladiator);

            generatedGladiators.Add(generatedGladiator);
        }
        
    }

    public void setRandomRace(GameObject gladiator){
        int randomRace = Random.Range(0, gladiator.GetComponent<AppereanceManager>().racesDict.Count);
        gladiator.GetComponent<AppereanceManager>().currentRace = randomRace;

        int randomRegion = Random.Range(0, 3);
        gladiator.GetComponent<AppereanceManager>().currentRegion = randomRegion;

        gladiator.GetComponent<AppereanceManager>().setRace();
        gladiator.GetComponent<AppereanceManager>().setRegion();
    }



}
