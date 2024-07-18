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

    private void ChangeSkinColor(){
        Transform modelObject = gameObject.transform.Find("GladiatorModel");

        Transform head = modelObject.transform.Find("head");
        Transform torso = modelObject.transform.Find("torso");

        Transform rightArm = modelObject.transform.Find("right_arm");
        Transform rightForearm = modelObject.transform.Find("right_forearm");

        Transform leftArm = modelObject.transform.Find("left_arm");
        Transform leftForearm = modelObject.transform.Find("left_forearm");

        Transform rightLeg = modelObject.transform.Find("right_leg");
        Transform rightCalf = modelObject.transform.Find("right_calf");

        Transform leftLeg = modelObject.transform.Find("left_leg");
        Transform leftCalf = modelObject.transform.Find("left_calf");

        Transform leftFoot = modelObject.transform.Find("left_foot");
        Transform rightFoot = modelObject.transform.Find("right_foot");
    }
}
