using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpsManager : MonoBehaviour
{
    public GameObject hitPopUpTextPrefab;
    public bool 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitPopUp(){
        StartCoroutine(HitPopUpCoroutine());
    }

    IEnumerator HitPopUpCoroutine(){

        GameObject popup = Instantiate(hitPopUpTextPrefab);

        yield return new WaitForSeconds(1.8f);

        Destroy(popup);

    }
}
