using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    float destroy

    void Start()
    {
        
    }

    public IEnumerator destroyAfterTimeCoroutine(float timeS){
        yield return new WaitForSeconds(timeS);

        Destroy(gameObject);
    }
}
