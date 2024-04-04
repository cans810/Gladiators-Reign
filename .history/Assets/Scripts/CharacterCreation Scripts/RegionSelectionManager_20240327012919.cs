using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegionSelectionManager : MonoBehaviour
{
    public int currentRegionNum;

    public Dictionary<int,string> regionsDict;

    private List<Sprite> currentLook;

    public List<List<int>> listOfLists = new List<List<int>>();
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
        regionsDict = new Dictionary<int, string>();
        regionsDict.Add(0,"Eldorian");
        regionsDict.Add(1,"Mistvalian");
        regionsDict.Add(2,"Avalorian");
    }

    public void nextRegion(){
        if (currentRegionNum < 3-1){
            currentRegionNum++;
            detectCurrentRace();
            changeLooks();

            currentRegionText.text = regionsDict[currentRegionNum];
        }
    }

    public void prevRegion(){
        if (currentRegionNum > 0){
            currentRegionNum--;
            detectCurrentRace();
            changeLooks();

            currentRegionText.text = regionsDict[currentRegionNum];
        }
    }

    public void detectCurrentRace(){
        if (GetComponent<RaceSelectionManager>().racesDict[GetComponent<RaceSelectionManager>().currentRace].Equals("Human")){
            if (regionsDict[currentRegionNum] == "Eldorian"){
                currentLook = humanRegion_Eldorian;
            }
            else if (regionsDict[currentRegionNum] == "Mistvalian"){
                currentLook = humanRegion_Mistvalian;
            }
            else if (regionsDict[currentRegionNum] == "Avalorian"){
                currentLook = humanRegion_Avalorian;
            }
        }
    }

    public void changeLooks(){
        if (currentLook[0] != null){
            eye_brows.sprite = currentLook[0];
        }
        if (currentLook[1] != null){
            eyes.sprite = currentLook[1];
        }
        if (currentLook[2] != null){
            nose.sprite = currentLook[2];
        }
        if (currentLook[3] != null){
            mouth.sprite = currentLook[3];
        }
        // accessories
        if (currentLook.Count >= 5 && currentLook[4] != null){
            accessory_1.sprite = currentLook[4];
        }
        if (currentLook.Count >= 6 && currentLook[5] != null){
            accessory_2.sprite = currentLook[5];
        }
    }
}
