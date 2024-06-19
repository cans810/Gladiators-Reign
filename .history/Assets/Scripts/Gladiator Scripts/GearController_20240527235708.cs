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


    public Inventory inventory;


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

    public void WearHelmet(GameObject helmetToWear){
        helmetToWear.transform.SetParent(helmetSpot.transform);
        helmetToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        helmetToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        helmetToWear.transform.localScale = Vector3.one; // Optional: reset scale
    }

    public void WearChestplate(GameObject chestplateToWear){
        chestplateToWear.transform.SetParent(chestplateSpot.transform);
        chestplateToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        chestplateToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        chestplateToWear.transform.localScale = Vector3.one; // Optional: reset scale
    }

    public void WearShoulderguard(GameObject shoulderGuardRightToWear, GameObject shoulderGuardLeftToWear){
        shoulderGuardRightToWear.transform.SetParent(shoulderguardSpot_right.transform);
        shoulderGuardRightToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        shoulderGuardRightToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        shoulderGuardRightToWear.transform.localScale = Vector3.one; // Optional: reset scale

        shoulderGuardLeftToWear.transform.SetParent(shoulderguardSpot_left.transform);
        shoulderGuardLeftToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        shoulderGuardLeftToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        shoulderGuardLeftToWear.transform.localScale = Vector3.one; // Optional: reset scale
        shoulderGuardLeftToWear.GetComponent<SpriteRenderer>().sortingOrder = 3;
    }

    public void WearWristguard(GameObject wristGuardRightToWear, GameObject wristGuardLeftToWear){
        wristGuardRightToWear.transform.SetParent(wristGuardSpot_right.transform);
        wristGuardRightToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        wristGuardRightToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        wristGuardRightToWear.transform.localScale = Vector3.one; // Optional: reset scale

        wristGuardLeftToWear.transform.SetParent(wristGuardSpot_left.transform);
        wristGuardLeftToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        wristGuardLeftToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        wristGuardLeftToWear.transform.localScale = Vector3.one; // Optional: reset scale
        wristGuardLeftToWear.GetComponent<SpriteRenderer>().sortingOrder = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpotFull(pantsSpot) && inventory.PantsWorn)
        {
            GameObject pants = GameObject.Instantiate(inventory.PantsWorn);
            pants.transform.SetParent(pantsSpot.transform);
            pants.transform.localPosition = Vector3.zero; // Optional: reset position
            pants.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            pants.transform.localScale = Vector3.one; // Optional: reset scale
        }

        if (!isSpotFull(legGuardSpot_right) && inventory.LegGuardWorn)
        {
            GameObject legGuard_Right = GameObject.Instantiate(inventory.LegGuardWorn);
            legGuard_Right.transform.SetParent(legGuardSpot_right.transform);
            legGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
            legGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            legGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale

            GameObject legGuard_Left = GameObject.Instantiate(inventory.LegGuardWorn);
            legGuard_Left.transform.SetParent(legGuardSpot_left.transform);
            legGuard_Left.transform.localPosition = Vector3.zero; // Optional: reset position
            legGuard_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            legGuard_Left.transform.localScale = Vector3.one; // Optional: reset scale

            legGuard_Left.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }

        if (!isSpotFull(shinGuardSpot_right) && inventory.ShinGuardWorn)
        {
            GameObject shinGuard_Right = GameObject.Instantiate(inventory.ShinGuardWorn);
            shinGuard_Right.transform.SetParent(shinGuardSpot_right.transform);
            shinGuard_Right.transform.localPosition = Vector3.zero; // Optional: reset position
            shinGuard_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shinGuard_Right.transform.localScale = Vector3.one; // Optional: reset scale

            GameObject shinGuard_Left = GameObject.Instantiate(inventory.ShinGuardWorn);
            shinGuard_Left.transform.SetParent(shinGuardSpot_left.transform);
            shinGuard_Left.transform.localPosition = Vector3.zero; // Optional: reset position
            shinGuard_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shinGuard_Left.transform.localScale = Vector3.one; // Optional: reset scale

            shinGuard_Left.GetComponent<SpriteRenderer>().sortingOrder = 11;
        }

        if (!isSpotFull(shoesSpot_right) && inventory.ShoesWorn)
        {
            GameObject shoes_Right = GameObject.Instantiate(inventory.ShoesWorn);
            shoes_Right.transform.SetParent(shoesSpot_right.transform);
            shoes_Right.transform.localPosition = Vector3.zero; // Optional: reset position
            shoes_Right.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shoes_Right.transform.localScale = Vector3.one; // Optional: reset scale

            GameObject shoes_Left = GameObject.Instantiate(inventory.ShoesWorn);
            shoes_Left.transform.SetParent(shoesSpot_left.transform);
            shoes_Left.transform.localPosition = Vector3.zero; // Optional: reset position
            shoes_Left.transform.localRotation = Quaternion.identity; // Optional: reset rotation
            shoes_Left.transform.localScale = Vector3.one; // Optional: reset scale

            shoes_Left.GetComponent<SpriteRenderer>().sortingOrder = 12;
        }
    }

    public bool isSpotFull(GameObject spot){
        if (spot.transform.childCount == 0){
            return false;
        }
        return true;
    }
}
