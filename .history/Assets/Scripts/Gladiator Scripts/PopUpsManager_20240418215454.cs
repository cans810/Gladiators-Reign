using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpsManager : MonoBehaviour
{
    public Attributes attributes;
    public GameObject hitPopUpTextPrefab;


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
        popup.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = attributes.amount_GotHit.ToString();

        popup.GetComponent<TextMeshProUGUI>().text = attributes.amount_GotHit.ToString();


        yield return new WaitForSeconds(1.8f);

        Destroy(popup);
    }
}
