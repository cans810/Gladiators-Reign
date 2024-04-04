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
        playerGladiator.GetComponent<AppereanceManager>().currentRegion = 0;
        playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = appereanceManager.racesSpriteLibraries[appereanceManager.currentRace];
        appereanceManager.setRace();

        currentRaceText.text = appereanceManager.racesDict[appereanceManager.currentRace];

        playerGladiator.GetComponent<AppereanceManager>().detectCurrentRace();

        playerGladiator.GetComponent<Attributes>().raceRegion = playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[playerGladiator.GetComponent<AppereanceManager>().currentRegion];
        GetComponent<RegionSelectionManager>().currentRegionText.text = 
        playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[playerGladiator.GetComponent<AppereanceManager>().currentRegion];

        playerGladiator.GetComponent<Attributes>().race = appereanceManager.racesDict[appereanceManager.currentRace];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void nextRace(){
        if (appereanceManager.currentRace < appereanceManager.racesSpriteLibraries.Count-1){
            appereanceManager.currentRace++;
            appereanceManager.setRace();

            playerGladiator.GetComponent<AppereanceManager>().currentRegion = 0;
            playerGladiator.GetComponent<AppereanceManager>().setRegion();

            currentRaceText.text = appereanceManager.racesDict[appereanceManager.currentRace];
            GetComponent<RegionSelectionManager>().currentRegionText.text = playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[playerGladiator.GetComponent<AppereanceManager>().currentRegion];
        }
    }

    public void prevRace(){
        if (appereanceManager.currentRace > 0){
            appereanceManager.currentRace--;
            appereanceManager.setRace();

            playerGladiator.GetComponent<AppereanceManager>().currentRegion = 0;
            playerGladiator.GetComponent<AppereanceManager>().detectCurrentRace();

            currentRaceText.text = appereanceManager.racesDict[appereanceManager.currentRace];
            GetComponent<RegionSelectionManager>().currentRegionText.text = playerGladiator.GetComponent<AppereanceManager>().currentRegionsDict[playerGladiator.GetComponent<AppereanceManager>().currentRegion];
        }
    }
}
