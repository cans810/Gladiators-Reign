using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorGenerator : MonoBehaviour
{

    public GameObject fightOption;

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


    public void GenerateRandomGladiator(){
        if (generatedGladiator == null){
            StartCoroutine(GenerateRandomGladiatorCoroutine());
        }
    }

    IEnumerator GenerateRandomGladiatorCoroutine()
    {
        fightOption.SetActive(true);

        generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
        Animator animator = generatedGladiator.GetComponent<Animator>();
        animator.SetBool("GeneratedGladiatorShow", true);

        generatedGladiator.transform.position = generatedGladiatorPosition.position;

        // Wait until the animation ends
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Set the animation parameter to false
        animator.SetBool("GeneratedGladiatorShow", false);
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
