using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class RaceSelectionManager : MonoBehaviour
{
    public GameObject playerGladiator;
    public List<SpriteLibraryAsset> races;
    public int currentRace;
    public Dictionary<int,string> racesDict;

    public Color humanSkinColor;
    public Color elfSkinColor;

    // Start is called before the first frame update
    void Start()
    {
        racesDict
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void nextRace(){
        if (currentRace < races.Count-1){
            currentRace++;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = races[currentRace];
            setSkinColor();
        }
    }

    public void prevRace(){
        if (currentRace > 0){
            currentRace--;
            playerGladiator.GetComponent<SpriteLibrary>().spriteLibraryAsset = races[currentRace];
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
    }

    private void ChangeSkinColor(Color skinColor){
        Transform head = playerGladiator.transform.Find("head");
        Transform torso = playerGladiator.transform.Find("torso");

        Transform rightArm = playerGladiator.transform.Find("arm_right");
        Transform rightForearm = playerGladiator.transform.Find("forearm_right");

        Transform leftArm = playerGladiator.transform.Find("arm_left");
        Transform leftForearm = playerGladiator.transform.Find("forearm_left");

        Transform rightLeg = playerGladiator.transform.Find("right_leg");
        Transform rightCalf = playerGladiator.transform.Find("right_calf");

        Transform leftLeg = playerGladiator.transform.Find("left_leg");
        Transform leftCalf = playerGladiator.transform.Find("left_calf");

        Transform leftFoot = playerGladiator.transform.Find("left_foot");
        Transform rightFoot = playerGladiator.transform.Find("right_foot");

        
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
