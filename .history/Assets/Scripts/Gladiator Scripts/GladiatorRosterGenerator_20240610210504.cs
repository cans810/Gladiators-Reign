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
            generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            setRandomRace();
        }
        
        
        
    }

    public void GenerateRandomGladiator(){
        if (generatedGladiator == null){
            StartCoroutine(GenerateRandomGladiatorCoroutine());
        }
    }

    IEnumerator GenerateRandomGladiatorCoroutine()
    {
        //fightOption.SetActive(true);
        enterBattleButton.SetActive(true);

        generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
        setRandomRace();

        Animator animator = generatedGladiator.GetComponent<Animator>();
        generatedGladiator.GetComponent<AnimationsManager>().StartAnim("GeneratedGladiatorShow");

        generatedGladiator.transform.position = generatedGladiatorPosition.position;

        // Wait until the animation ends
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Set the animation parameter to false
        generatedGladiator.GetComponent<AnimationsManager>().StopAnim("GeneratedGladiatorShow");
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

    public void hideGeneratedGladiator(){
        // hide after waiting for 2 secs
        StartCoroutine(hideGeneratedGladiatorCoroutine());
    }

    IEnumerator hideGeneratedGladiatorCoroutine(){
        yield return new WaitForSeconds(0.6f);

        if (generatedGladiator != null)
        {
           generatedGladiator.transform.position = new Vector3(generatedGladiator.transform.position.x, generatedGladiator.transform.position.y, -10);
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
