using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public GameObject playerPos;

    public GameObject armorObjectPrefab;
    public GameObject itemStandPrefab;
    
    public List<GameObject> armorPoss;
    public List<GameObject> allHelmetObjects;

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.gameObject.transform.position = playerPos.transform.position;

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<1; i++){
                GameObject helmet = Instantiate(allHelmetObjects[i]);
                helmet.transform.position = armorPoss[i].transform.position;
                helmet.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
                helmet.GetComponent<Armor>().texture.sortingLayerName = "middle";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
