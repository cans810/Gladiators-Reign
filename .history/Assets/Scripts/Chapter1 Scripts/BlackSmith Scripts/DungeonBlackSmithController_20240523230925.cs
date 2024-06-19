using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public GameObject playerPos;

    public GameObject armorObjectPrefab;
    public List<GameObject> armorPoss;
    public List<Armor> allHelmetObjects;

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.gameObject.transform.position = playerPos.transform.position;

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<1; i++){
                GameObject helmetObject = Instantiate(armorObjectPrefab);
                helmetObject.GetComponent<ArmorObject>().scriptableObject = allHelmetObjects
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
