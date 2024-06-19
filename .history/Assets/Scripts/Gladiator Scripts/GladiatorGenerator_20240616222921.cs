using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorGenerator : MonoBehaviour
{
    public GameObject gladiatorPrefab;
    public Transform generatedGladiatorPosition;

    public GameObject generatedGladiator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Dungeons_GenerateRandomGladiator(){
        if (generatedGladiator == null){

            generatedGladiator = GameObject.Instantiate(gladiatorPrefab);

            generatedGladiator.transform.position = generatedGladiatorPosition.position;
            setRandomRace();
        }
    }

        public void setRandomRace(){
        int randomRace = Random.Range(0, generatedGladiator.GetComponent<AppereanceManager>().racesDict.Count);
        generatedGladiator.GetComponent<AppereanceManager>().currentRace = randomRace;

        generatedGladiator.GetComponent<AppereanceManager>().setRace();
    }

    public void destroyGeneratedGladiator(){
        // destroy after waiting for 2 secs
        StartCoroutine(destroyGeneratedGladiatorCoroutine());
    }

    IEnumerator destroyGeneratedGladiatorCoroutine(){
        yield return new WaitForSeconds(0.6f);

        if (generatedGladiator != null)
        {
            Destroy(generatedGladiator);
        }
    }


}
