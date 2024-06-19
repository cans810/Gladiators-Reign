using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    public GameObject helmetSpot;
    public GameObject chestplateSpot;
    public GameObject shoulderguardSpot_right;
    public GameObject shoulderguardSpot_left;
    public GameObject wristGuardSpot_right;
    public GameObject wristGuardSpot_left;
    public GameObject pantsSpot;
    public GameObject legGuardSpot_right;
    public GameObject legGuardSpot_left;
    public GameObject shinGuardSpot_right;
    public GameObject shinGuardSpot_left;
    public GameObject shoesSpot_right;
    public GameObject shoesSpot_left;


    public Item HelmetWorn;
    public Item ChestplateWorn;
    public Item ShoulderguardWorn;
    public Item WristGuardWorn;
    public Item PantsWorn;
    public Item LegGuardWorn;
    public Item ShinGuardWorn;
    public Item ShoesWorn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (helmetSpot != null){
            if (HelmetWorn == null){
                helmetSpot.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                helmetSpot.GetComponent<SpriteRenderer>().sprite = HelmetWorn.texture;
            }
        }

        if (chestplateSpot != null){
            if (ChestplateWorn == null){
                chestplateSpot.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                chestplateSpot.GetComponent<SpriteRenderer>().sprite = ChestplateWorn.texture;
            }
        }

        if (shoulderguardSpot_right != null){
            if (ShoulderguardWorn == null){
                shoulderguardSpot_right.GetComponent<SpriteRenderer>().sprite = null;
                shoulderguardSpot_left.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                shoulderguardSpot_right.GetComponent<SpriteRenderer>().sprite = ShoulderguardWorn.texture;
                shoulderguardSpot_left.GetComponent<SpriteRenderer>().sprite = ShoulderguardWorn.texture;
            }
        }

        if (wristGuardSpot_right != null){
            if (WristGuardWorn == null){
                wristGuardSpot_right.GetComponent<SpriteRenderer>().sprite = null;
                wristGuardSpot_left.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                wristGuardSpot_right.GetComponent<SpriteRenderer>().sprite = WristGuardWorn.texture;
                wristGuardSpot_left.GetComponent<SpriteRenderer>().sprite = WristGuardWorn.texture;
            }
        }

        if (pantsSpot != null){
            if (PantsWorn == null){
                pantsSpot.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                pantsSpot.GetComponent<SpriteRenderer>().sprite = PantsWorn.texture;
            }
        }

        if (legGuardSpot_right != null){
            if (LegGuardWorn == null){
                legGuardSpot_right.GetComponent<SpriteRenderer>().sprite = null;
                legGuardSpot_left.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                legGuardSpot_right.GetComponent<SpriteRenderer>().sprite = LegGuardWorn.texture;
                legGuardSpot_left.GetComponent<SpriteRenderer>().sprite = LegGuardWorn.texture;
            }
        }

        if (shinGuardSpot_right != null){
            if (ShinGuardWorn == null){
                shinGuardSpot_right.GetComponent<SpriteRenderer>().sprite = null;
                shinGuardSpot_left.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                shinGuardSpot_right.GetComponent<SpriteRenderer>().sprite = ShinGuardWorn.texture;
                shinGuardSpot_left.GetComponent<SpriteRenderer>().sprite = ShinGuardWorn.texture;
            }
        }

        if (shinGuardSpot_right != null){
            if (ShinGuardWorn == null){
                shinGuardSpot_right.GetComponent<SpriteRenderer>().sprite = null;
                shinGuardSpot_left.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                shinGuardSpot_right.GetComponent<SpriteRenderer>().sprite = ShinGuardWorn.texture;
                shinGuardSpot_left.GetComponent<SpriteRenderer>().sprite = ShinGuardWorn.texture;
            }
        }
    }
}
