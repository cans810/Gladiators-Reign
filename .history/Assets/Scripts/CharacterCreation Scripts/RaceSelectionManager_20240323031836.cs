using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class RaceSelectionManager : MonoBehaviour
{
    public GameObject playerGladiator;
    public List<SpriteLibraryAsset> races;
    public int currentRace;

    public Color currentSkinColor;
    public Color humanSkinColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void nextRace(){
        if (currentRace <= races.Count){
            currentRace++;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = races[currentRace];
        }
    }

    public void prevRace(){
        if (currentRace <<=> races.Count){
            currentRace++;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = races[currentRace];
        }
        currentRace--;
        playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = races[currentRace];
    }
}
