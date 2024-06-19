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


    public GameObject HelmetWorn;
    public GameObject ChestplateWorn;
    public GameObject ShoulderguardWorn;
    public GameObject WristGuardWorn;
    public GameObject PantsWorn;
    public GameObject LegGuardWorn;
    public GameObject ShinGuardWorn;
    public GameObject ShoesWorn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UnequipGear(GameObject gearPart){
        foreach (Transform child in gearPart.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (helmetSpot != null)
        {
            if (HelmetWorn == null)
            {
                UnequipGear(helmetSpot);
            }
            else
            {
                GameObject helmet = GameObject.Instantiate(HelmetWorn);
                helmet.transform.SetParent(helmetSpot.transform);
                helmet.transform.localPosition = Vector3.zero; // Optional: reset position
                helmet.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                helmet.transform.localScale = Vector3.one; // Optional: reset scale
            }
        }

        if (chestplateSpot != null)
        {
            if (ChestplateWorn == null)
            {
                UnequipGear(chestplateSpot);
            }
            else
            {
                GameObject chestplate = GameObject.Instantiate(ChestplateWorn);
                chestplate.transform.SetParent(chestplateSpot.transform);
                chestplate.transform.localPosition = Vector3.zero; // Optional: reset position
                chestplate.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                chestplate.transform.localScale = Vector3.one; // Optional: reset scale
            }
        }

        if (shoulderguardSpot_right != null)
        {
            if (ChestplateWorn == null)
            {
                UnequipGear(shoulderguardSpot_right);
            }
            else
            {
                GameObject shoulderGuard_Right = GameObject.Instantiate(ChestplateWorn);
                shoulderGuard_Right.transform.SetParent(shoulderguardSpot_right.transform);
                shoulderGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
                shoulderGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                shoulderGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale
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

        if (shoesSpot_right != null){
            if (ShoesWorn == null){
                shoesSpot_right.GetComponent<SpriteRenderer>().sprite = null;
                shoesSpot_left.GetComponent<SpriteRenderer>().sprite = null;
            }
            else{
                shoesSpot_right.GetComponent<SpriteRenderer>().sprite = ShoesWorn.texture;
                shoesSpot_left.GetComponent<SpriteRenderer>().sprite = ShoesWorn.texture;
            }
        }
    }
}
