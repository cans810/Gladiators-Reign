using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class RaceSelectionManager : MonoBehaviour
{
    public GameObject playerGladiator;
    public AppereanceManager appereanceManager;

    public TextMeshProUGUI currentRaceText;

    // Start is called before the first frame update
    void Start()
    {
        // initial look
        appereanceManager.currentRace = 0;
        GetComponent<RegionSelectionManager>().currentRegionNum = 0;
        playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = appereanceManager.racesSpriteLibraries[appereanceManager.currentRace];
        appereanceManager.setSkinColor();

        currentRaceText.text = appereanceManager.racesDict[appereanceManager.currentRace];

        GetComponent<RegionSelectionManager>().detectCurrentRace();

        playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];
        GetComponent<RegionSelectionManager>().currentRegionText.text = 
        GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];

        playerGladiator.GetComponent<Attributes>().race = appereanceManager.racesDict[appereanceManager.currentRace];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void nextRace(){
        if (appereanceManager.currentRace < appereanceManager.racesSpriteLibraries.Count-1){
            appereanceManager.currentRace++;
            appereanceManager.setSkinColor();

            GetComponent<RegionSelectionManager>().currentRegionNum = 0;
            GetComponent<RegionSelectionManager>().detectCurrentRace();

            GetComponent<RegionSelectionManager>().currentRegionText.text = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];

            playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];

            currentRaceText.text = appereanceManager.racesDict[appereanceManager.currentRace];
        }
    }

    public void prevRace(){
        if (appereanceManager.currentRace > 0){
            appereanceManager.currentRace--;
            appereanceManager.setSkinColor();

            GetComponent<RegionSelectionManager>().currentRegionNum = 0;
            GetComponent<RegionSelectionManager>().detectCurrentRace();

            playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];

            currentRaceText.text = appereanceManager.racesDict[appereanceManager.currentRace];
            GetComponent<RegionSelectionManager>().currentRegionText.text = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];
        }
    }
}
