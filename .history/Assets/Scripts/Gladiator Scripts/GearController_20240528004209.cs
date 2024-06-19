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
        if (inventory.HelmetWorn != null && !isSpotFull(helmetSpot)){
            GameObject itemGenerated = Instantiate(inventory.HelmetWorn);
            WearHelmet(itemGenerated);
        }
        if (inventory.ChestplateWorn != null && !isSpotFull(chestplateSpot)){
            GameObject itemGenerated = Instantiate(inventory.HelmetWorn);
            WearChestplate(itemGenerated);
        }
        if (inventory.ShoulderguardWorn != null && !isSpotFull(shoulderguardSpot_right)){
            GameObject itemGenerated = Instantiate(inventory.HelmetWorn);
            GameObject itemGeneratedPair = Instantiate(inventory.HelmetWorn);
            WearShoulderguard(itemGenerated, itemGeneratedPair);
        }
        if (inventory.WristGuardWorn != null && !isSpotFull(wristGuardSpot_right)){
            GameObject itemGenerated = Instantiate(inventory.WristGuardWorn);
            GameObject itemGeneratedPair = Instantiate(inventory.WristGuardWorn);
            WearWristguard(itemGenerated, itemGeneratedPair);
        }
        if (inventory.PantsWorn != null && !isSpotFull(pantsSpot)){
            GameObject itemGenerated = Instantiate(inventory.PantsWorn);
            WearPants(itemGenerated);
        }
        if (inventory.LegGuardWorn != null){
            GameObject itemGenerated = Instantiate(inventory.HelmetWorn);
            WearLegguard(inventory.LegGuardWorn, inventory.LegGuardWorn);
        }
        if (inventory.ShinGuardWorn != null){
            GameObject itemGenerated = Instantiate(inventory.HelmetWorn);
            WearShinguard(inventory.ShinGuardWorn, inventory.ShinGuardWorn);
        }
        if (inventory.ShoesWorn != null){
            GameObject itemGenerated = Instantiate(inventory.HelmetWorn);
            WearShoe(inventory.ShoesWorn, inventory.ShoesWorn);
        }
    }

    public void UnequipGear(GameObject gearPart){
        foreach (Transform child in gearPart.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void WearHelmet(GameObject helmetToWear){
        if (isSpotFull(helmetSpot)){
            UnequipGear(helmetSpot);
        }

        inventory.HelmetWorn = helmetToWear;

        helmetToWear.transform.SetParent(helmetSpot.transform);
        helmetToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        helmetToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        helmetToWear.transform.localScale = Vector3.one; // Optional: reset scale
    }

    public void WearChestplate(GameObject chestplateToWear){
        if (isSpotFull(chestplateSpot)){
            UnequipGear(chestplateSpot);
        }

        inventory.ChestplateWorn = chestplateToWear;

        chestplateToWear.transform.SetParent(chestplateSpot.transform);
        chestplateToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        chestplateToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        chestplateToWear.transform.localScale = Vector3.one; // Optional: reset scale
    }

    public void WearShoulderguard(GameObject shoulderGuardRightToWear, GameObject shoulderGuardLeftToWear){
        if (isSpotFull(shoulderguardSpot_right)){
            UnequipGear(shoulderguardSpot_right);
            UnequipGear(shoulderguardSpot_left);
        }

        inventory.ShoulderguardWorn = shoulderGuardRightToWear;

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
        if (isSpotFull(wristGuardSpot_right)){
            UnequipGear(wristGuardSpot_right);
            UnequipGear(wristGuardSpot_left);
        }

        inventory.WristGuardWorn = wristGuardRightToWear;

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

    public void WearPants(GameObject pantToWear){
        if (isSpotFull(pantsSpot)){
            UnequipGear(wristGuardSpot_right);
        }

        inventory.PantsWorn = pantToWear;

        pantToWear.transform.SetParent(pantsSpot.transform);
        pantToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        pantToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        pantToWear.transform.localScale = Vector3.one; // Optional: reset scale
    }

    public void WearLegguard(GameObject legGuardRightToWear, GameObject legGuardLeftToWear){
        inventory.LegGuardWorn = legGuardRightToWear;

        legGuardRightToWear.transform.SetParent(legGuardSpot_right.transform);
        legGuardRightToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        legGuardRightToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        legGuardRightToWear.transform.localScale = Vector3.one; // Optional: reset scale

        legGuardLeftToWear.transform.SetParent(legGuardSpot_left.transform);
        legGuardLeftToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        legGuardLeftToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        legGuardLeftToWear.transform.localScale = Vector3.one; // Optional: reset scale
        legGuardLeftToWear.GetComponent<SpriteRenderer>().sortingOrder = 3;
    }

    public void WearShinguard(GameObject shinGuardRightToWear, GameObject shinGuardLeftToWear){
        inventory.ShinGuardWorn = shinGuardRightToWear;

        shinGuardRightToWear.transform.SetParent(shinGuardSpot_right.transform);
        shinGuardRightToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        shinGuardRightToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        shinGuardRightToWear.transform.localScale = Vector3.one; // Optional: reset scale

        shinGuardLeftToWear.transform.SetParent(shinGuardSpot_left.transform);
        shinGuardLeftToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        shinGuardLeftToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        shinGuardLeftToWear.transform.localScale = Vector3.one; // Optional: reset scale
        shinGuardLeftToWear.GetComponent<SpriteRenderer>().sortingOrder = 3;
    }

    public void WearShoe(GameObject shoeGuardRightToWear, GameObject shoeGuardLeftToWear){
        inventory.ShoesWorn = shoeGuardRightToWear;

        shoeGuardRightToWear.transform.SetParent(shoesSpot_right.transform);
        shoeGuardRightToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        shoeGuardRightToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        shoeGuardRightToWear.transform.localScale = Vector3.one; // Optional: reset scale

        shoeGuardLeftToWear.transform.SetParent(shoesSpot_left.transform);
        shoeGuardLeftToWear.transform.localPosition = Vector3.zero; // Optional: reset position
        shoeGuardLeftToWear.transform.localRotation = Quaternion.identity; // Optional: reset rotation
        shoeGuardLeftToWear.transform.localScale = Vector3.one; // Optional: reset scale
        shoeGuardLeftToWear.GetComponent<SpriteRenderer>().sortingOrder = 12;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool isSpotFull(GameObject spot){
        if (spot.transform.childCount == 0){
            return false;
        }
        return true;
    }
}
