using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegionSelectionManager : MonoBehaviour
{
    public int currentRegionNum;

    public Dictionary<int,string> currentRegionsDict;
    public Dictionary<int,string> humanRegionsDict;
    public Dictionary<int,string> elfRegionsDict;

    private List<Sprite> currentLook;

    public List<Sprite> humanRegion_Eldorian;
    public List<Sprite> humanRegion_Mistvalian;
    public List<Sprite> humanRegion_Avalorian;

    public SpriteRenderer eye_brows;
    public SpriteRenderer eyes;
    public SpriteRenderer nose;
    public SpriteRenderer mouth;
    public SpriteRenderer accessory_1;
    public SpriteRenderer accessory_2;

    public TextMeshProUGUI currentRegionText;

    public void Awake(){
        humanRegionsDict = new Dictionary<int, string>();
        humanRegionsDict.Add(0,"Eldorian");
        humanRegionsDict.Add(1,"Mistvalian");
        humanRegionsDict.Add(2,"Avalorian");

        elfRegionsDict = new Dictionary<int, string>();
        elfRegionsDict.Add(0,"...");
        elfRegionsDict.Add(1,"???");
        elfRegionsDict.Add(2,"***");
    }

    public void Update(){
    }

    public void nextRegion(){
        if (currentRegionNum < 3-1){
            currentRegionNum++;

            currentRegionText.text = currentRegionsDict[currentRegionNum];
        }
    }

    public void prevRegion(){
        if (currentRegionNum > 0){
            currentRegionNum--;

            currentRegionText.text = currentRegionsDict[currentRegionNum];
        }
    }

}
