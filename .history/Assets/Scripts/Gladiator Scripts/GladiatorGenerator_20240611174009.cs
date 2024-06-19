using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorGenerator : MonoBehaviour
{
    public GameObject fightOption;
    public GameObject enterBattleButton;

    public GameObject gladiatorPrefab;
    public Transform generatedGladiatorPosition;

    public GameObject generatedGladiator;

    // Start is called before the first frame update
    void Start()
    {
        generatedGladiator = GameObject.Find("GladiatorObject(Clone)");

        if (generatedGladiator != null && generatedGladiator.tag != "Player"){
            if (SceneManager.GetActiveScene().name == "DungeonScene"){
                generatedGladiator.transform.position = new Vector3(-100,-100,-100);
            }
            else{
                generatedGladiator.transform.position = generatedGladiatorPosition.position;
            }
            enterBattleButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Dungeons_GenerateRandomGladiator(){
        if (generatedGladiator == null){
            enterBattleButton.SetActive(true);

            generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            //outside the view
            generatedGladiator.transform.position = new Vector3(-100,-100,-100);
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

        generatedGladiator.GetComponent<AppereanceManager>().setRace();
    }


}
