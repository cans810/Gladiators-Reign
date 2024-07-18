using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLTrainingManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendToTraining(){
        gladiator.GetComponent<GLState>().isTraining = true;
        gladiator.transform.position = new Vector3(-100,-100,-100);

        StartCoroutine(trainingCoroutine(gladiator));
    }

    public IEnumerator trainingCoroutine(GameObject gladiator){
        yield return new WaitForSeconds(10f);

        gladiator.GetComponent<GLState>().isTraining = false;
    }
}
