using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpsManager : MonoBehaviour
{
    public Attributes attributes;
    public GameObject hitPopUpTextPrefab;
    public bool hitPopUpExists;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitPopUpExists && attributes.gotHit){
            HitPopUp();
        }
    }

    public void HitPopUp(){
        StartCoroutine(HitPopUpCoroutine());
    }

    IEnumerator HitPopUpCoroutine(){
        hitPopUpExists = true;

        GameObject popup = Instantiate(hitPopUpTextPrefab);

        yield return new WaitForSeconds(1.8f);

        Destroy(popup);
        hitPopUpExists = false;
    }
}
