using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime;

    void Start()
    {
        StartCoroutine(destroyAfterTimeCoroutine(destroyTime))
    }

    public IEnumerator destroyAfterTimeCoroutine(float timeS){
        yield return new WaitForSeconds(timeS);

        Destroy(gameObject);
    }
}
