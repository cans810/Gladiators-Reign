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
        if (!isSpotFull(helmetSpot) && HelmetWorn)
        {
            GameObject helmet = GameObject.Instantiate(HelmetWorn);
            helmet.transform.SetParent(helmetSpot.transform);
            helmet.transform.localPosition = Vector3.zero; // Optional: reset position
            helmet.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            helmet.transform.localScale = Vector3.one; // Optional: reset scale
        }

        if (!isSpotFull(chestplateSpot) && ChestplateWorn)
        {
            GameObject chestplate = GameObject.Instantiate(ChestplateWorn);
            chestplate.transform.SetParent(chestplateSpot.transform);
            chestplate.transform.localPosition = Vector3.zero; // Optional: reset position
            chestplate.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            chestplate.transform.localScale = Vector3.one; // Optional: reset scale
        }

        if (!isSpotFull(shinGuardSpot_right) && ShinGuardWorn)
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

        if (!isSpotFull(wristGuardSpot_right) && WristGuardWorn)
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

        if (!isSpotFull(pantsSpot) && PantsWorn)
        {
            GameObject pants = GameObject.Instantiate(PantsWorn);
            pants.transform.SetParent(pantsSpot.transform);
            pants.transform.localPosition = Vector3.zero; // Optional: reset position
            pants.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            pants.transform.localScale = Vector3.one; // Optional: reset scale
        }

        if (!isSpotFull(legGuardSpot_right)     )
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

        if (!isSpotFull(shinGuardSpot_right))
        {
            GameObject shinGuard_Right = GameObject.Instantiate(ShinGuardWorn);
            shinGuard_Right.transform.SetParent(shinGuardSpot_right.transform);
            shinGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
            shinGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shinGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale

            GameObject shinGuard_Left = GameObject.Instantiate(ShinGuardWorn);
            shinGuard_Left.transform.SetParent(shinGuardSpot_left.transform);
            shinGuard_Left.transform.localPosition = Vector3.zero; // Optional: reset position
            shinGuard_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shinGuard_Left.transform.localScale = Vector3.one; // Optional: reset scale
        }

        if (!isSpotFull(shinGuardSpot_right))
        {
            GameObject shoes_Right = GameObject.Instantiate(ShoesWorn);
            shoes_Right.transform.SetParent(shoesSpot_right.transform);
            shoes_Right.transform.localPosition = Vector3.zero; // Optional: reset position
            shoes_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shoes_Right.transform.localScale = Vector3.one; // Optional: reset scale

            GameObject shoes_Left = GameObject.Instantiate(ShoesWorn);
            shoes_Left.transform.SetParent(shoesSpot_left.transform);
            shoes_Left.transform.localPosition = Vector3.zero; // Optional: reset position
            shoes_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shoes_Left.transform.localScale = Vector3.one; // Optional: reset scale
        }
    }

    public bool isSpotFull(GameObject spot){
        if (spot.transform.childCount == 0){
            return false;
        }
        return true;
    }
}
