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
        playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
        setSkinColor();

        currentRaceText.text = racesDict[currentRace];

        GetComponent<RegionSelectionManager>().detectCurrentRace();

        playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];
        GetComponent<RegionSelectionManager>().currentRegionText.text = 
        GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];

        playerGladiator.GetComponent<Attributes>().race = racesDict[currentRace];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void nextRace(){
        if (currentRace < racesSpriteLibraries.Count-1){
            currentRace++;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
            setSkinColor();

            GetComponent<RegionSelectionManager>().currentRegionNum = 0;
            GetComponent<RegionSelectionManager>().detectCurrentRace();

            currentRaceText.text = racesDict[currentRace];
            playerGladiator.GetComponent<Attributes>().race = racesDict[currentRace];


            GetComponent<RegionSelectionManager>().currentRegionText.text = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];

            playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];
        }
    }

    public void prevRace(){
        if (currentRace > 0){
            currentRace--;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
            setSkinColor();

            GetComponent<RegionSelectionManager>().currentRegionNum = 0;
            GetComponent<RegionSelectionManager>().detectCurrentRace();

            currentRaceText.text = racesDict[currentRace];
            playerGladiator.GetComponent<Attributes>().race = racesDict[currentRace];


            GetComponent<RegionSelectionManager>().currentRegionText.text = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];

            playerGladiator.GetComponent<Attributes>().raceRegion = GetComponent<RegionSelectionManager>().currentRegionsDict[GetComponent<RegionSelectionManager>().currentRegionNum];
        }
    }
}
