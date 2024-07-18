using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class AppereanceManager : MonoBehaviour
{
    public List<SpriteLibraryAsset> racesSpriteLibraries;

    public Dictionary<int,string> racesDict;

    public int currentRace;

    public void Awake(){
        racesDict = new Dictionary<int, string>();
        racesDict.Add(0,"Human");
        racesDict.Add(1,"Elf");
        racesDict.Add(2,"Orc");
        racesDict.Add(3,"Troll");
        racesDict.Add(4,"Demon");
        //racesDict.Add(5,"Wraith");
    }

    public void setRandomAppereance(){

    }

    public void setRace(){
        GetComponent<GLAttributes>().race = racesDict[currentRace];
        GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
    }
}
