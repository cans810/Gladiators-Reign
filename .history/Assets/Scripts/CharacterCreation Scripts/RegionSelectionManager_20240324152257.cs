using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionSelectionManager : MonoBehaviour
{
    public int currentRegionNum;
    public List<Sprite> humanRegion_1Look;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextRegion(){
        if (currentRace < racesSpriteLibraries.Count-1){
            currentRace++;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
            setSkinColor();
        }
    }

    public void prevRegion(){
        if (currentRace > 0){
            currentRace--;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
            setSkinColor();
        }
    }
}
