using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpsManager : MonoBehaviour
{
    public GameObject hitPopUpTextPrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HitPopUp(int amount_GotHit){
        StartCoroutine(HitPopUpCoroutine(amount_GotHit));
    }

    IEnumerator HitPopUpCoroutine(int amount_GotHit){

        GameObject popup = Instantiate(hitPopUpTextPrefab);
        pop.

        popup.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = amount_GotHit.ToString();

        yield return new WaitForSeconds(1.8f);

        Destroy(popup);
    }
}
