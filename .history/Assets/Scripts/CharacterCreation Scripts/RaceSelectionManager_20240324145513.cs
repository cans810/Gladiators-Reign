using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class RaceSelectionManager : MonoBehaviour
{
    public GameObject playerGladiator;
    public List<SpriteLibraryAsset> racesSpriteLibraries;
    public int currentRace;
    public Dictionary<int,string> racesDict;

    public Color humanSkinColor;
    public Color elfSkinColor;
    public Color easternHumanSkinColor;
    public Color orcSkinColor;

    // Start is called before the first frame update
    void Start()
    {
        racesDict = new Dictionary<int, string>();
        racesDict.Add(0,"Human");
        racesDict.Add(1,"Elf");
        racesDict.Add(2,"Eastern Human");
        racesDict.Add(2,"Orc");
        
        // initial look
        playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
        setSkinColor();
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
        }
    }

    public void prevRace(){
        if (currentRace > 0){
            currentRace--;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = racesSpriteLibraries[currentRace];
            setSkinColor();
        }
    }

    public void setSkinColor(){
        if (racesDict[currentRace].Equals("Human")){
            ChangeSkinColor(humanSkinColor);
        }
        else if(racesDict[currentRace].Equals("Elf")){
            ChangeSkinColor(elfSkinColor);
        }
        else if(racesDict[currentRace].Equals("Orc")){
            ChangeSkinColor(orcSkinColor);
        }
    }

    private void ChangeSkinColor(Color skinColor){
        Transform modelObject = playerGladiator.transform.Find("GladiatorModel");

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
