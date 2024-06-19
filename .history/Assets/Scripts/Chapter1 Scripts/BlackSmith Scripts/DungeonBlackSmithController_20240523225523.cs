using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public GameObject playerPos;

    public GameObject armorPos1;

    public List<ArmorObject> allHelmetObjects;

    // Start is called before the first frame update
    void Start()
    {
        // armorPos's
        armorPos1 = gameObject.transform.Find("armorPos1").gameObject;

        Player.Instance.gameObject.transform.position = playerPos.transform.position;

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<allHelmetObjects.Count; i++){
                allHelmetObjects[i].transform.position
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
