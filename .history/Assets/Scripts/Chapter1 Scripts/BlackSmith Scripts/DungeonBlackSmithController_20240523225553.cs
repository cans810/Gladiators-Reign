using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public GameObject playerPos;

    public List<GameObject> armorPoss;

    public List<ArmorObject> allHelmetObjects;

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.gameObject.transform.position = playerPos.transform.position;

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<allHelmetObjects.Count; i++){
                allHelmetObjects[i].transform.position = armorPos1.transform.position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
