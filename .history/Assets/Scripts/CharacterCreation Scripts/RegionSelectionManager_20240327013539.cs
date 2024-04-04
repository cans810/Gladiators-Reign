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

    public List<List<Sprite>> regionsList;

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

        regionsList.Add(humanRegion_Eldorian);
        regionsList.Add(humanRegion_Mistvalian);
        regionsList.Add(humanRegion_Avalorian);
    }

    public void nextRegion(){
        if (currentRegionNum < 3-1){
            currentRegionNum++;
            detectCurrentRace();
            changeLooks();

            currentRegionText.text = currentRegionsDict[currentRegionNum];
        }
    }

    public void prevRegion(){
        if (currentRegionNum > 0){
            currentRegionNum--;
            detectCurrentRace();
            changeLooks();

            currentRegionText.text = currentRegionsDict[currentRegionNum];
        }
    }

    public void detectCurrentRace(){
        if (GetComponent<RaceSelectionManager>().racesDict[GetComponent<RaceSelectionManager>().currentRace].Equals("Human")){
            currentRegionsDict = humanRegionsDict;

            if (currentRegionsDict[currentRegionNum] == "Eldorian"){
                currentLook = humanRegion_Eldorian;
            }
            else if (currentRegionsDict[currentRegionNum] == "Mistvalian"){
                currentLook = humanRegion_Mistvalian;
            }
            else if (currentRegionsDict[currentRegionNum] == "Avalorian"){
                currentLook = humanRegion_Avalorian;
            }
        }
        else if (GetComponent<RaceSelectionManager>().racesDict[GetComponent<RaceSelectionManager>().currentRace].Equals("Human")){
            currentRegionsDict = humanRegionsDict;

            if (currentRegionsDict[currentRegionNum] == "Eldorian"){
                currentLook = humanRegion_Eldorian;
            }
            else if (currentRegionsDict[currentRegionNum] == "Mistvalian"){
                currentLook = humanRegion_Mistvalian;
            }
            else if (currentRegionsDict[currentRegionNum] == "Avalorian"){
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
