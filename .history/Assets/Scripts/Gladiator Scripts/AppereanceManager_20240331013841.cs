using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class AppereanceManager : MonoBehaviour
{
    public List<SpriteLibraryAsset> racesSpriteLibraries;

    public Dictionary<int,string> racesDict;

    public Color humanSkinColor;
    public Color elfSkinColor;
    public Color easternHumanSkinColor;
    public Color orcSkinColor;
    public Color trollSkinColor;
    public Color demonSkinColor;
    public Color wraithSkinColor;

    public int currentRace;

    public int currentRegion;

    public Dictionary<int,string> currentRegionsDict;
    public Dictionary<int,string> humanRegionsDict;
    public Dictionary<int,string> elfRegionsDict;
    public Dictionary<int,string> easternHumanRegionsDict;
    public Dictionary<int,string> orcRegionsDict;

    public void Awake(){
        racesDict = new Dictionary<int, string>();
        racesDict.Add(0,"Human");
        racesDict.Add(1,"Elf");
        racesDict.Add(2,"Eastern Human");
        racesDict.Add(3,"Orc");
        racesDict.Add(4,"Troll");
        racesDict.Add(5,"Demon");
        racesDict.Add(6,"Wraith");

        humanRegionsDict = new Dictionary<int, string>();
        humanRegionsDict.Add(0,"Eldorian");
        humanRegionsDict.Add(1,"Mistvalian");
        humanRegionsDict.Add(2,"Avalorian");

        elfRegionsDict = new Dictionary<int, string>();
        elfRegionsDict.Add(0,"...");
        elfRegionsDict.Add(1,"???");
        elfRegionsDict.Add(2,"***");

        easternHumanRegionsDict = new Dictionary<int, string>();
        easternHumanRegionsDict.Add(0,"...");
        easternHumanRegionsDict.Add(1,"???");
        easternHumanRegionsDict.Add(2,"***");

        orcRegionsDict = new Dictionary<int, string>();
        orcRegionsDict.Add(0,"...");
        orcRegionsDict.Add(1,"???");
        orcRegionsDict.Add(2,"***");
    }

    public void setRandomAppereance(){

    }

    public void setRace(){
        if (racesDict[currentRace].Equals("Human")){
            ChangeSkinColor(humanSkinColor);
        }
        else if(racesDict[currentRace].Equals("Elf")){
            ChangeSkinColor(elfSkinColor);
        }
        else if(racesDict[currentRace].Equals("Eastern Human")){
            ChangeSkinColor(easternHumanSkinColor);
        }
        else if(racesDict[currentRace].Equals("Orc")){
            ChangeSkinColor(orcSkinColor);
        }
        else if(racesDict[currentRace].Equals("Troll")){
            ChangeSkinColor(trollSkinColor);
        }
        else if(racesDict[currentRace].Equals("Demon")){
            ChangeSkinColor(demonSkinColor);
        }
        else if(racesDict[currentRace].Equals("Wraith")){
            ChangeSkinColor(wraithSkinColor);
        }

        GetComponent<Attributes>().race = racesDict[currentRace];
        
    }

    public void setRegion(){
        if (racesDict[currentRace].Equals("Human")){

            currentRegionsDict = humanRegionsDict;
        }
        else if (racesDict[currentRace].Equals("Elf")){

            currentRegionsDict = elfRegionsDict;
        }
        else if (racesDict[currentRace].Equals("Eastern Human")){

            currentRegionsDict = elfRegionsDict;
        }
        else if (racesDict[currentRace].Equals("Orc")){

            currentRegionsDict = orcRegionsDict;
        }

        GetComponent<Attributes>().raceRegion = currentRegionsDict[currentRegion];
    }

    private void ChangeSkinColor(Color skinColor){
        Transform modelObject = gameObject.transform.Find("GladiatorModel");

        Transform head = modelObject.transform.Find("head");
        Transform torso = modelObject.transform.Find("torso");

        Transform rightArm = modelObject.transform.Find("arm_right");
        Transform rightForearm = modelObject.transform.Find("forearm_right");

        Transform leftArm = modelObject.transform.Find("arm_left");
        Transform leftForearm = modelObject.transform.Find("forearm_left");

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
