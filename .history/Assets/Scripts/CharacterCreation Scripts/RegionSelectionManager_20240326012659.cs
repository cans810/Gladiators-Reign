using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegionSelectionManager : MonoBehaviour
{
    public int currentRegionNum;
    
    public Dictionary<int,string> racesDict;

    private List<Sprite> currentLook;

    public List<Sprite> humanRegion_1Look;
    public List<Sprite> humanRegion_2Look;
    public List<Sprite> humanRegion_3Look;

    public SpriteRenderer eye_brows;
    public SpriteRenderer eyes;
    public SpriteRenderer nose;
    public SpriteRenderer mouth;
    public SpriteRenderer accessory_1;
    public SpriteRenderer accessory_2;

    public TextMeshProUGUI currentRaceText;

    public void nextRegion(){
        if (currentRegionNum < 3-1){
            currentRegionNum++;
            detectCurrentRace();
            changeLooks();
        }
    }

    public void prevRegion(){
        if (currentRegionNum > 0){
            currentRegionNum--;
            detectCurrentRace();
            changeLooks();
        }
    }

    public void detectCurrentRace(){
        if (GetComponent<RaceSelectionManager>().racesDict[GetComponent<RaceSelectionManager>().currentRace].Equals("Human")){
            if (currentRegionNum == 0){
                currentLook = humanRegion_1Look;
            }
            else if (currentRegionNum == 1){
                currentLook = humanRegion_2Look;
            }
            else if (currentRegionNum == 2){
                currentLook = humanRegion_3Look;
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
        if (currentLook[4] != null){
            accessory_1.sprite = currentLook[4];
        }
        if (currentLook[5] != null){
            accessory_2.sprite = currentLook[5];
        }
    }
}
