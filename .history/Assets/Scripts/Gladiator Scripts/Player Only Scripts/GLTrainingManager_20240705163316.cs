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
        GetComponent<GLState>().isTraining = true;
        transform.position = new Vector3(-100,-100,-100);

        StartCoroutine(trainingCoroutine());
    }

    public IEnumerator trainingCoroutine(){
        yield return new WaitForSeconds(40f);

        GetComponent<GLState>().isTraining = false;
    }
}
