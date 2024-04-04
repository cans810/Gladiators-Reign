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
            detectCurrentRace();

            currentRegionText.text = currentRegionsDict[currentRegionNum];
            GetComponent<Attributes>().raceRegion = currentRegionsDict[currentRegionNum];
        }
    }

    public void prevRegion(){
        if (currentRegionNum > 0){
            currentRegionNum--;
            detectCurrentRace();

            GetComponent<RaceSelectionManager>().playerGladiator.currentRegionText.text = currentRegionsDict[currentRegionNum];
        }
    }

    public void detectCurrentRace(){
        if (GetComponent<RaceSelectionManager>().racesDict[GetComponent<RaceSelectionManager>().currentRace].Equals("Human")){
            currentRegionsDict = humanRegionsDict;
        }
        else if (GetComponent<RaceSelectionManager>().racesDict[GetComponent<RaceSelectionManager>().currentRace].Equals("Elf")){
            currentRegionsDict = elfRegionsDict;
        }
    }
}
