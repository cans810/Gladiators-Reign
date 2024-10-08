using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public Material spriteLitMaterial;

    public GameObject playerPos;

    public GameObject itemStandPrefab;

    public List<GameObject> armorPoss;
    public List<GameObject> allHelmetObjects;

    public void Awake(){
        Player.Instance.GetComponent<Attributes>().ChangeMaterial(spriteLitMaterial);
    }

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.gameObject.transform.position = playerPos.transform.position;

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            for (int i=0; i<1; i++){
                GameObject itemStand = Instantiate(itemStandPrefab);
                itemStand.transform.position = armorPoss[i].transform.position;
                itemStand.transform.position = new Vector2(itemStand.transform.position.x, itemStand.transform.position.y - 1.2f);
                itemStand.GetComponent<SpriteRenderer>().material = spriteLitMaterial;

                GameObject helmet = Instantiate(allHelmetObjects[i]);
                helmet.transform.position = armorPoss[i].transform.position;
                helmet.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
                helmet.GetComponent<Armor>().texture.sortingLayerName = "middle";
                helmet.GetComponent<SpriteRenderer>().material = spriteLitMaterial;

                helmet.transform.SetParent(itemStand.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToDungeon(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
