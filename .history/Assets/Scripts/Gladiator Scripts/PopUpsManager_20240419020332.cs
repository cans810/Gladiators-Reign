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
        float randomDistanceX = Random.Range(5,10);
        float randomDistanceY = Random.Range(5,10);

        GameObject popup = Instantiate(hitPopUpTextPrefab, new Vector3(opponent.transform.position.x + 10, opponent.transform.position.y, opponent.transform.position.z), Quaternion.identity);

        TextMeshPro textMeshPro = popup.GetComponentInChildren<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.text = amount_GotHit.ToString();
        }
        else
        {
            Debug.LogError("TextMeshProUGUI component not found in the child objects of the hitPopUpTextPrefab.");
        }

        yield return new WaitForSeconds(1.8f);

        Destroy(popup);
    }
}
