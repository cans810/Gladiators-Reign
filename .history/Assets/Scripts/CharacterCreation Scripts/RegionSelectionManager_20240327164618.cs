using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegionSelectionManager : MonoBehaviour
{
    public TextMeshProUGUI currentRegionText;

    public void Update(){
    }

    public void nextRegion(){
        if (GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegion < 3-1){
            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegion++;
            detectCurrentRace();

            currentRegionText.text = GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegion];
            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[currentRegion];
        }
    }

    public void prevRegion(){
        if (GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegion > 0){
            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegion--;
            detectCurrentRace();

            currentRegionText.text = GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegion];
            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegion];
        }
    }

    public void detectCurrentRace(){
        if (GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.
        racesDict[GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.currentRace].Equals("Human")){

            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict = GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().humanRegionsDict;
        }
        else if (GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.
        racesDict[GetComponent<RaceSelectionManager>().GetComponent<RaceSelectionManager>().appereanceManager.currentRace].Equals("Elf")){

            GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict = GetComponent<RaceSelectionManager>().playerGladiator.GetComponent<AppereanceManager>().elfRegionsDict;
        }
    }
}
