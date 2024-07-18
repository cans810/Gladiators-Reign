using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class AppereanceManager : MonoBehaviour
{
    public List<SpriteLibraryAsset> racesSpriteLibraries;

    public Dictionary<int,string> racesDict;

    public Color humanSkinColor;

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

        // else if(racesDict[currentRace].Equals("Wraith")){
        //     ChangeSkinColor(wraithSkinColor);
        // }

        GetComponent<GLAttributes>().race = racesDict[currentRace];
        GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
    }

    private void ChangeSkinColor(Color skinColor){
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

        
        GameObject childObject_head = head.gameObject;
        childObject_head.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_torso = torso.gameObject;
        childObject_torso.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightArm = rightArm.gameObject;
        childObject_rightArm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightForearm = rightForearm.gameObject;
        childObject_rightForearm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftArm = leftArm.gameObject;
        childObject_leftArm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftForearm = leftForearm.gameObject;
        childObject_leftForearm.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightLeg = rightLeg.gameObject;
        childObject_rightLeg.GetComponent<SpriteRenderer>().color = skinColor;
        GameObject childObject_rightCalf = rightCalf.gameObject;
        childObject_rightCalf.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftLeg = leftLeg.gameObject;
        childObject_leftLeg.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftCalf = leftCalf.gameObject;
        childObject_leftCalf.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_leftFoot = leftFoot.gameObject;
        childObject_leftFoot.GetComponent<SpriteRenderer>().color = skinColor;

        GameObject childObject_rightFoot = rightFoot.gameObject;
        childObject_rightFoot.GetComponent<SpriteRenderer>().color = skinColor;
    }
}
