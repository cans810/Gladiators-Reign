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
        generatedGladiator.GetComponent<Animator>().SetBool("GeneratedGladiatorShow",);

        generatedGladiator.transform.position = generatedGladiatorPosition.transform.position;

    }


}
