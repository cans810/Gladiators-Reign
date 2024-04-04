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
    
    public TextMeshProUGUI currentRegionText;

    public void Awake(){
    }

    public void Update(){
    }

    public void nextRegion(){
        if (currentRegionNum < 3-1){
            currentRegionNum++;
            detectCurrentRace();

            currentRegionText.text = currentRegionsDict[currentRegionNum];
            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<Attributes>().raceRegion = currentRegionsDict[currentRegionNum];
        }
    }

    public void prevRegion(){
        if (currentRegionNum > 0){
            currentRegionNum--;
            detectCurrentRace();

            currentRegionText.text = currentRegionsDict[currentRegionNum];
            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<Attributes>().raceRegion = currentRegionsDict[currentRegionNum];
        }
    }

    public void detectCurrentRace(){
        if (GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.
        racesDict[GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.currentRace].Equals("Human")){

            currentRegionsDict = humanRegionsDict;
        }
        else if (GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.
        racesDict[GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.currentRace].Equals("Elf")){

            currentRegionsDict = elfRegionsDict;
        }
    }
}
