using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorGenerator : MonoBehaviour
{
    public GameObject gladiatorPrefab;
    public Transform generatedGladiatorPosition;
    public int gladiatorSpacing;

    public List<GameObject> generatedGladiators;

    // Start is called before the first frame update
    void Start()
    {
        generatedGladiators = new List<GameObject>();

        Dungeons_GenerateRandomGladiator(2);

        float totalWidth = (generatedGladiators.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = generatedGladiatorPosition.transform.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < generatedGladiators.Count; i++)
        {
            if (i >= generatedGladiators.Count)
            {
                continue;
            }
            adjustGladiatorTransform(generatedGladiators[i], startPosition + new Vector3(i * gladiatorSpacing, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Dungeons_GenerateRandomGladiator(int gladiator_amount){
        for (int i=0; i<gladiator_amount; i++){
            GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            setRandomRace(generatedGladiator);

            generatedGladiator.GetComponent<GLAttributes>().InitGladiator(1,1,1,1,1,1,1,1,1,1,0);

            generatedGladiators.Add(generatedGladiator);
        }
    }

    public void setRandomRace(GameObject generatedGladiator){
        int randomRace = Random.Range(0, generatedGladiator.GetComponent<AppereanceManager>().racesDict.Count);
        generatedGladiator.GetComponent<AppereanceManager>().currentRace = randomRace;

        generatedGladiator.GetComponent<AppereanceManager>().setRace();
    }

    public void adjustGladiatorTransform(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(3f, 3f, 3f);
    }


}
