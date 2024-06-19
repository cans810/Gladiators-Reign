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
            if (ShoulderguardWorn == null)
            {
                UnequipGear(shoulderguardSpot_right);
                UnequipGear(shoulderguardSpot_left);
            }
            else
            {
                GameObject shoulderGuard_Right = GameObject.Instantiate(ShoulderguardWorn);
                shoulderGuard_Right.transform.SetParent(shoulderguardSpot_right.transform);
                shoulderGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
                shoulderGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                shoulderGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale

                GameObject shoulderGuard_Left = GameObject.Instantiate(ShoulderguardWorn);
                shoulderGuard_Left.transform.SetParent(shoulderguardSpot_left.transform);
                shoulderGuard_Left.transform.localPosition = Vector3.zero; // Optional: reset position
                shoulderGuard_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                shoulderGuard_Left.transform.localScale = Vector3.one; // Optional: reset scale
            }
        }

        if (wristGuardSpot_right != null)
        {
            if (WristGuardWorn == null)
            {
                UnequipGear(wristGuardSpot_right);
                UnequipGear(wristGuardSpot_left);
            }
            else
            {
                GameObject wristGuard_Right = GameObject.Instantiate(WristGuardWorn);
                wristGuard_Right.transform.SetParent(wristGuardSpot_right.transform);
                wristGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
                wristGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                wristGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale

                GameObject wristGuard_Left = GameObject.Instantiate(WristGuardWorn);
                wristGuard_Left.transform.SetParent(wristGuardSpot_left.transform);
                wristGuard_Left.transform.localPosition = Vector3.zero; // Optional: reset position
                wristGuard_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                wristGuard_Left.transform.localScale = Vector3.one; // Optional: reset scale
            }
        }

        if (pantsSpot != null)
        {
            if (PantsWorn == null)
            {
                UnequipGear(pantsSpot);
            }
            else
            {
                GameObject pants = GameObject.Instantiate(PantsWorn);
                pants.transform.SetParent(pantsSpot.transform);
                pants.transform.localPosition = Vector3.zero; // Optional: reset position
                pants.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                pants.transform.localScale = Vector3.one; // Optional: reset scale
            }
        }

        if (legGuardSpot_right != null)
        {
            if (LegGuardWorn == null)
            {
                UnequipGear(legGuardSpot_right);
                UnequipGear(legGuardSpot_left);
            }
            else
            {
                GameObject legGuard_Right = GameObject.Instantiate(LegGuardWorn);
                legGuard_Right.transform.SetParent(legGuardSpot_right.transform);
                legGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
                legGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                legGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale

                GameObject legGuard_Left = GameObject.Instantiate(LegGuardWorn);
                legGuard_Left.transform.SetParent(legGuardSpot_left.transform);
                legGuard_Left.transform.localPosition = Vector3.zero; // Optional: reset position
                legGuard_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                legGuard_Left.transform.localScale = Vector3.one; // Optional: reset scale
            }
        }

        if (shinGuardSpot_right != null)
        {
            if (ShinGuardWorn == null)
            {
                UnequipGear(shinGuardSpot_right);
                UnequipGear(shinGuardSpot_left);
            }
            else
            {
                GameObject shinGuard_Right = GameObject.Instantiate(ShinGuardWorn);
                shinGuard_Right.transform.SetParent(legGuardSpot_right.transform);
                shinGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
                shinGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                shinGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale

                GameObject shinGuard_Left = GameObject.Instantiate(LegGuardWorn);
                shinGuard_Left.transform.SetParent(legGuardSpot_left.transform);
                shinGuard_Left.transform.localPosition = Vector3.zero; // Optional: reset position
                shinGuard_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
                shinGuard_Left.transform.localScale = Vector3.one; // Optional: reset scale
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
