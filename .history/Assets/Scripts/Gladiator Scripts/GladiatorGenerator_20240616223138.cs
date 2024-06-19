using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorGenerator : MonoBehaviour
{
    public GameObject gladiatorPrefab;
    public Transform generatedGladiatorPosition;

    public List<GameObject> generatedGladiators;

    // Start is called before the first frame update
    void Start()
    {
        Dungeons_GenerateRandomGladiator();

        float totalWidth = (GameManager.Instance.playerGLs.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            if (i >= GameManager.Instance.playerGLs.Count)
            {
                continue;
            }
            adjustGladiatorTransform(GameManager.Instance.playerGLs[i], startPosition + new Vector3(i * gladiatorSpacing, 0, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Dungeons_GenerateRandomGladiator(int gladiator_amount){
        
        for (int i=0;i<gladiator_amount;i++){
            
        }

        GameObject.Instantiate(gladiatorPrefab);
        setRandomRace();
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
