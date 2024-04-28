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

    public void HitPopUp(int amount_GotHit, GameObject opponent)
    {
        StartCoroutine(HitPopUpCoroutine(amount_GotHit, opponent));
    }

    IEnumerator HitPopUpCoroutine(int amount_GotHit, GameObject opponent)
    {
        GameObject popup = Instantiate(hitPopUpTextPrefab, new Vector3(opponent.transform.position.x + 10, opponent.transform.position.y, transform.position.z), Quaternion.identity);

        popup.transform.Find("Text").gameObject.GetComponent<TextMeshProUGUI>().text = amount_GotHit.ToString();

        yield return new WaitForSeconds(1.8f);

        Destroy(popup);
    }
}
