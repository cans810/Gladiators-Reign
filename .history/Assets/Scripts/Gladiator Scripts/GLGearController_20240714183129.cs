using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLGearController : MonoBehaviour
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

    public GameObject handEquipmentSpot_right;
    public GameObject handEquipmentSpot_left;


    public GLInventory inventory;

    public void Update(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGearLayer();
    }

    void FixedUpdate() {
        UpdateGearLayer();
    }

    public void UnequipGear(GameObject gearPart, GameObject gearPartPair){
        foreach (Transform child in gearPart.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (gearPartPair != null){
            foreach (Transform child in gearPartPair.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public void WearRighthandEquipment(GameObject equipmentToWear){
        if (equipmentToWear != null){
            if (isSpotFull(handEquipmentSpot_right)){
                UnequipGear(handEquipmentSpot_right, null);
            }

            equipmentToWear.transform.SetParent(handEquipmentSpot_right.transform);
            equipmentToWear.transform.localPosition = inventory.RightHandWorn.transform.localPosition; // Optional: reset position
            equipmentToWear.transform.localRotation = inventory.RightHandWorn.transform.localRotation; // Optional: reset rotation
            equipmentToWear.transform.localScale = inventory.RightHandWorn.transform.localScale; // Optional: reset scale
        }
    }

    public void WearLefthandEquipment(GameObject equipmentToWear){
        if (equipmentToWear != null){
        if (isSpotFull(handEquipmentSpot_left)){
            UnequipGear(handEquipmentSpot_left, null);
        }

        equipmentToWear.transform.SetParent(handEquipmentSpot_left.transform);
        equipmentToWear.transform.localPosition = inventory.LeftHandWorn.transform.localPosition; // Optional: reset position
        equipmentToWear.transform.localRotation = inventory.LeftHandWorn.transform.localRotation; // Optional: reset rotation
        equipmentToWear.transform.localScale = inventory.LeftHandWorn.transform.localScale; // Optional: reset scale
        }
    }

    public void WearHelmet(GameObject helmetToWear, GameObject prefab){
        if (helmetToWear != null && prefab != null){
        if (isSpotFull(helmetSpot)){
            UnequipGear(helmetSpot, null);
        }

        helmetToWear.transform.SetParent(helmetSpot.transform);
        helmetToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        helmetToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        helmetToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
        }
    }

    public void WearChestplate(GameObject chestplateToWear, GameObject prefab){
        if (chestplateToWear != null && prefab != null){
        if (isSpotFull(chestplateSpot)){
            UnequipGear(chestplateSpot, null);
        }

        chestplateToWear.transform.SetParent(chestplateSpot.transform);
        chestplateToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        chestplateToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        chestplateToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
        }
    }

    public void WearShoulderguard(GameObject shoulderGuardRightToWear, GameObject shoulderGuardLeftToWear, GameObject prefab){
        if (shoulderGuardRightToWear != null && shoulderGuardLeftToWear != null && prefab != null){
        if (isSpotFull(shoulderguardSpot_right)){
            UnequipGear(shoulderguardSpot_right, shoulderguardSpot_left);
        }

        //inventory.ShoulderguardWorn = shoulderGuardRightToWear;

        shoulderGuardRightToWear.transform.SetParent(shoulderguardSpot_right.transform);
        shoulderGuardRightToWear.transform.localPosition = prefab.transform.localPosition;
        shoulderGuardRightToWear.transform.localRotation = prefab.transform.localRotation;
        shoulderGuardRightToWear.transform.localScale = prefab.transform.localScale;

        shoulderGuardLeftToWear.transform.SetParent(shoulderguardSpot_left.transform);
        shoulderGuardLeftToWear.transform.localPosition = prefab.transform.position;
        shoulderGuardLeftToWear.transform.localRotation = prefab.transform.localRotation;
        shoulderGuardLeftToWear.transform.localScale =prefab.transform.localScale;
        }
    }

    public void WearWristguard(GameObject wristGuardRightToWear, GameObject wristGuardLeftToWear, GameObject prefab){
        if (wristGuardRightToWear != null && wristGuardLeftToWear != null && prefab != null){
        if (isSpotFull(wristGuardSpot_right)){
            UnequipGear(wristGuardSpot_right, wristGuardSpot_left);
        }

        wristGuardRightToWear.transform.SetParent(wristGuardSpot_right.transform);
        wristGuardRightToWear.transform.localPosition = prefab.transform.localPosition;
        wristGuardRightToWear.transform.localRotation = prefab.transform.localRotation;
        wristGuardRightToWear.transform.localScale = prefab.transform.localScale;

        wristGuardLeftToWear.transform.SetParent(wristGuardSpot_left.transform);
        wristGuardLeftToWear.transform.localPosition = prefab.transform.localPosition;
        wristGuardLeftToWear.transform.localRotation = prefab.transform.localRotation;
        wristGuardLeftToWear.transform.localScale = prefab.transform.localScale;
        }
    }

    public void WearPants(GameObject pantToWear, GameObject prefab){
        if (pantToWear != null && prefab != null){
        if (isSpotFull(pantsSpot)){
            UnequipGear(pantsSpot, null);
        }

        pantToWear.transform.SetParent(pantsSpot.transform);
        pantToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        pantToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        pantToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
        }
    }

    public void WearLegguard(GameObject legGuardRightToWear, GameObject legGuardLeftToWear, GameObject prefab){
        if (legGuardRightToWear != null && legGuardLeftToWear != null && prefab != null){
        if (isSpotFull(legGuardSpot_right)){
            UnequipGear(legGuardSpot_right, legGuardSpot_left);
        }

        legGuardRightToWear.transform.SetParent(legGuardSpot_right.transform);
        legGuardRightToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        legGuardRightToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        legGuardRightToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale

        legGuardLeftToWear.transform.SetParent(legGuardSpot_left.transform);
        legGuardLeftToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        legGuardLeftToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        legGuardLeftToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
        }
    }

    public void WearShinguard(GameObject shinGuardRightToWear, GameObject shinGuardLeftToWear, GameObject prefab){
        if (shinGuardRightToWear != null && shinGuardLeftToWear != null && prefab != null){
        if (isSpotFull(shinGuardSpot_right)){
            UnequipGear(shinGuardSpot_right, shinGuardSpot_left);
        }

        shinGuardRightToWear.transform.SetParent(shinGuardSpot_right.transform);
        shinGuardRightToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        shinGuardRightToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        shinGuardRightToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale

        shinGuardLeftToWear.transform.SetParent(shinGuardSpot_left.transform);
        shinGuardLeftToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        shinGuardLeftToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        shinGuardLeftToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
        }
    }

    public void WearShoe(GameObject shoeGuardRightToWear, GameObject shoeGuardLeftToWear, GameObject prefab){
        if (shoeGuardRightToWear != null && shoeGuardLeftToWear != null && prefab != null){
        if (isSpotFull(shoesSpot_right)){
            UnequipGear(shoesSpot_right, shoesSpot_left);
        }

        shoeGuardRightToWear.transform.SetParent(shoesSpot_right.transform);
        shoeGuardRightToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        shoeGuardRightToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        shoeGuardRightToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale

        shoeGuardLeftToWear.transform.SetParent(shoesSpot_left.transform);
        shoeGuardLeftToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        shoeGuardLeftToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        shoeGuardLeftToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
        }
    }

    public bool isSpotFull(GameObject spot){
        if (spot.transform.childCount == 0){
            return false;
        }
        return true;
    }

    public GameObject getItemInSpot(GameObject spot){
        return spot.transform.GetChild(0).gameObject;
    }

    public void UpdateGearLayer()
    {
        UpdateGearSortingLayer(helmetSpot, "head");
        UpdateGearSortingLayer(chestplateSpot, "torso");
        UpdateGearSortingLayer(shoulderguardSpot_right, "right_arm");
        UpdateGearSortingLayer(shoulderguardSpot_left, "left_arm");
        UpdateGearSortingLayer(wristGuardSpot_right, "right_forearm");
        UpdateGearSortingLayer(wristGuardSpot_left, "left_forearm");
        UpdateGearSortingLayer(pantsSpot, "lower_torso");
        UpdateGearSortingLayer(legGuardSpot_right, "right_leg");
        UpdateGearSortingLayer(legGuardSpot_left, "left_leg");
        UpdateGearSortingLayer(shinGuardSpot_right, "right_calf");
        UpdateGearSortingLayer(shinGuardSpot_left, "left_calf");
        UpdateGearSortingLayer(shoesSpot_right, "right_foot");
        UpdateGearSortingLayer(shoesSpot_left, "left_foot");
        UpdateGearSortingLayer(handEquipmentSpot_right, "right_forearm");
        UpdateGearSortingLayer(handEquipmentSpot_left, "left_forearm");
    }

    private void UpdateGearSortingLayer(GameObject spot, string bodyPartName)
    {
        if (isSpotFull(spot))
        {
            GameObject bodyPart = GameObject.Find(bodyPartName);
            SpriteRenderer bodyPartRenderer = bodyPart.GetComponent<SpriteRenderer>();
            SpriteRenderer itemRenderer = getItemInSpot(spot).GetComponent<SpriteRenderer>();

            itemRenderer.sortingLayerName = bodyPartRenderer.sortingLayerName;
            itemRenderer.sortingOrder = bodyPartRenderer.sortingOrder + 1;
        }
    }

}
