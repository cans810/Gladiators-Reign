using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorGenerator : MonoBehaviour
{

    public GameObject fightOption;

    public GameObject gladiatorPrefab;
    public Transform generatedGladiatorPosition;

    public GameObject currentGladiatorGenerated;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GenerateRandomGladiator(){
        fightOption.SetActive(true);

        GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
        generatedGladiator.GetComponent<Animator>().SetBool("GeneratedGladiatorShow",true);

        generatedGladiator.transform.position = generatedGladiatorPosition.transform.position;

    }

    IEnumerator GenerateRandomGladiatorCoroutine()
    {
        fightOption.SetActive(true);

        GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
        Animator animator = generatedGladiator.GetComponent<Animator>();
        animator.SetBool("GeneratedGladiatorShow", true);

        generatedGladiator.transform.position = generatedGladiatorPosition.position;

        // Wait until the animation ends
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Set the animation parameter to false
        animator.SetBool("GeneratedGladiatorShow", false);

        // Deactivate the fight option
        fightOption.SetActive(false);
    }


}
