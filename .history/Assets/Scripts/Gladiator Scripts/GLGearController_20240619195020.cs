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

        // if (inventory.HelmetWorn != null && !isSpotFull(helmetSpot)){
        //     GameObject itemGenerated = Instantiate(inventory.HelmetWorn);
        //     WearHelmet(itemGenerated);
        // }
        // if (inventory.ChestplateWorn != null && !isSpotFull(chestplateSpot)){
        //     GameObject itemGenerated = Instantiate(inventory.ChestplateWorn);
        //     WearChestplate(itemGenerated);
        // }
        // if (inventory.ShoulderguardWorn != null && !isSpotFull(shoulderguardSpot_right)){
        //     GameObject itemGenerated = Instantiate(inventory.ShoulderguardWorn);
        //     GameObject itemGeneratedPair = Instantiate(inventory.ShoulderguardWorn);
        //     WearShoulderguard(itemGenerated, itemGeneratedPair);
        // }
        // if (inventory.WristGuardWorn != null && !isSpotFull(wristGuardSpot_right)){
        //     GameObject itemGenerated = Instantiate(inventory.WristGuardWorn);
        //     GameObject itemGeneratedPair = Instantiate(inventory.WristGuardWorn);
        //     WearWristguard(itemGenerated, itemGeneratedPair);
        // }
        // if (inventory.PantsWorn != null && !isSpotFull(pantsSpot)){
        //     GameObject itemGenerated = Instantiate(inventory.PantsWorn);
        //     WearPants(itemGenerated);
        // }
        // if (inventory.LegGuardWorn != null && !isSpotFull(legGuardSpot_right)){
        //     GameObject itemGenerated = Instantiate(inventory.LegGuardWorn);
        //     GameObject itemGeneratedPair = Instantiate(inventory.LegGuardWorn);
        //     WearLegguard(itemGenerated, itemGeneratedPair);
        // }
        // if (inventory.ShinGuardWorn != null && !isSpotFull(shinGuardSpot_right)){
        //     GameObject itemGenerated = Instantiate(inventory.ShinGuardWorn);
        //     GameObject itemGeneratedPair = Instantiate(inventory.ShinGuardWorn);
        //     WearShinguard(itemGenerated, itemGeneratedPair);
        // }
        // if (inventory.ShoesWorn != null && !isSpotFull(shoesSpot_right)){
        //     GameObject itemGenerated = Instantiate(inventory.ShoesWorn);
        //     GameObject itemGeneratedPair = Instantiate(inventory.ShoesWorn);
        //     WearShoe(itemGenerated, itemGeneratedPair);
        // }

        // if (inventory.RightHandWorn != null && !isSpotFull(handEquipmentSpot_right)){
        //     GameObject itemGenerated = Instantiate(inventory.RightHandWorn);
        //     WearRighthandEquipment(itemGenerated);
        // }
        // if (inventory.LeftHandWorn != null && !isSpotFull(handEquipmentSpot_left)){
        //     GameObject itemGenerated = Instantiate(inventory.LeftHandWorn);
        //     WearLefthandEquipment(itemGenerated);
        // }

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
        if (isSpotFull(handEquipmentSpot_right)){
            UnequipGear(handEquipmentSpot_right, null);
        }

        equipmentToWear.transform.SetParent(handEquipmentSpot_right.transform);
        equipmentToWear.transform.localPosition = inventory.RightHandWorn.transform.localPosition; // Optional: reset position
        equipmentToWear.transform.localRotation = inventory.RightHandWorn.transform.localRotation; // Optional: reset rotation
        equipmentToWear.transform.localScale = inventory.RightHandWorn.transform.localScale; // Optional: reset scale
    }

    public void WearLefthandEquipment(GameObject equipmentToWear){
        if (isSpotFull(handEquipmentSpot_left)){
            UnequipGear(handEquipmentSpot_left, null);
        }

        equipmentToWear.transform.SetParent(handEquipmentSpot_left.transform);
        equipmentToWear.transform.localPosition = inventory.LeftHandWorn.transform.localPosition; // Optional: reset position
        equipmentToWear.transform.localRotation = inventory.LeftHandWorn.transform.localRotation; // Optional: reset rotation
        equipmentToWear.transform.localScale = inventory.LeftHandWorn.transform.localScale; // Optional: reset scale
    }

    public void WearHelmet(GameObject helmetToWear, GameObject prefab){
        if (isSpotFull(helmetSpot)){
            UnequipGear(helmetSpot, null);
        }

        helmetToWear.transform.SetParent(helmetSpot.transform);
        helmetToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        helmetToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        helmetToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
    }

    public void WearChestplate(GameObject chestplateToWear, GameObject prefab){
        if (isSpotFull(chestplateSpot)){
            UnequipGear(chestplateSpot, null);
        }

        chestplateToWear.transform.SetParent(chestplateSpot.transform);
        chestplateToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        chestplateToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        chestplateToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
    }

    public void WearShoulderguard(GameObject shoulderGuardRightToWear, GameObject shoulderGuardLeftToWear, GameObject prefab){
        if (isSpotFull(shoulderguardSpot_right)){
            UnequipGear(shoulderguardSpot_right, shoulderguardSpot_left);
        }

        //inventory.ShoulderguardWorn = shoulderGuardRightToWear;

        shoulderGuardRightToWear.transform.SetParent(shoulderguardSpot_right.transform);
        Debug.Log(inventory.ShoulderguardWorn.transform.position);
        shoulderGuardRightToWear.transform.localPosition = prefab.transform.localPosition;
        shoulderGuardRightToWear.transform.localRotation = prefab.transform.localRotation;
        shoulderGuardRightToWear.transform.localScale = prefab.transform.localScale;

        shoulderGuardLeftToWear.transform.SetParent(shoulderguardSpot_left.transform);
        shoulderGuardLeftToWear.transform.localPosition = prefab.transform.position;
        shoulderGuardLeftToWear.transform.localRotation = prefab.transform.localRotation;
        shoulderGuardLeftToWear.transform.localScale =prefab.transform.localScale;
    }

    public void WearWristguard(GameObject wristGuardRightToWear, GameObject wristGuardLeftToWear, GameObject prefab){
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

    public void WearPants(GameObject pantToWear, GameObject prefab){
        if (isSpotFull(pantsSpot)){
            UnequipGear(pantsSpot, null);
        }

        pantToWear.transform.SetParent(pantsSpot.transform);
        pantToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        pantToWear.transform.localRotation = prefab.transform.localRotation; // Optional: reset rotation
        pantToWear.transform.localScale = prefab.transform.localScale; // Optional: reset scale
    }

    public void WearLegguard(GameObject legGuardRightToWear, GameObject legGuardLeftToWear, GameObject prefab){
        if (isSpotFull(legGuardSpot_right)){
            UnequipGear(legGuardSpot_right, legGuardSpot_left);
        }

        legGuardRightToWear.transform.SetParent(legGuardSpot_right.transform);
        legGuardRightToWear.transform.localPosition = prefab.transform.localPosition; // Optional: reset position
        legGuardRightToWear.transform.localRotation = inventory.LegGuardWorn.transform.localRotation; // Optional: reset rotation
        legGuardRightToWear.transform.localScale = inventory.LegGuardWorn.transform.localScale; // Optional: reset scale

        legGuardLeftToWear.transform.SetParent(legGuardSpot_left.transform);
        legGuardLeftToWear.transform.localPosition = inventory.LegGuardWorn.transform.localPosition; // Optional: reset position
        legGuardLeftToWear.transform.localRotation = inventory.LegGuardWorn.transform.localRotation; // Optional: reset rotation
        legGuardLeftToWear.transform.localScale = inventory.LegGuardWorn.transform.localScale; // Optional: reset scale
    }

    public void WearShinguard(GameObject shinGuardRightToWear, GameObject shinGuardLeftToWear, GameObject prefab){
        if (isSpotFull(shinGuardSpot_right)){
            UnequipGear(shinGuardSpot_right, shinGuardSpot_left);
        }

        shinGuardRightToWear.transform.SetParent(shinGuardSpot_right.transform);
        shinGuardRightToWear.transform.localPosition = inventory.ShinGuardWorn.transform.localPosition; // Optional: reset position
        shinGuardRightToWear.transform.localRotation = inventory.ShinGuardWorn.transform.localRotation; // Optional: reset rotation
        shinGuardRightToWear.transform.localScale = inventory.ShinGuardWorn.transform.localScale; // Optional: reset scale

        shinGuardLeftToWear.transform.SetParent(shinGuardSpot_left.transform);
        shinGuardLeftToWear.transform.localPosition = inventory.ShinGuardWorn.transform.localPosition; // Optional: reset position
        shinGuardLeftToWear.transform.localRotation = inventory.ShinGuardWorn.transform.localRotation; // Optional: reset rotation
        shinGuardLeftToWear.transform.localScale = inventory.ShinGuardWorn.transform.localScale; // Optional: reset scale
    }

    public void WearShoe(GameObject shoeGuardRightToWear, GameObject shoeGuardLeftToWear, GameObject prefab){
        if (isSpotFull(shoesSpot_right)){
            UnequipGear(shoesSpot_right, shoesSpot_left);
        }

        shoeGuardRightToWear.transform.SetParent(shoesSpot_right.transform);
        shoeGuardRightToWear.transform.localPosition = inventory.ShoesWorn.transform.localPosition; // Optional: reset position
        shoeGuardRightToWear.transform.localRotation = inventory.ShoesWorn.transform.localRotation; // Optional: reset rotation
        shoeGuardRightToWear.transform.localScale = inventory.ShoesWorn.transform.localScale; // Optional: reset scale

        shoeGuardLeftToWear.transform.SetParent(shoesSpot_left.transform);
        shoeGuardLeftToWear.transform.localPosition = inventory.ShoesWorn.transform.localPosition; // Optional: reset position
        shoeGuardLeftToWear.transform.localRotation = inventory.ShoesWorn.transform.localRotation; // Optional: reset rotation
        shoeGuardLeftToWear.transform.localScale = inventory.ShoesWorn.transform.localScale; // Optional: reset scale
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

    public void UpdateGearLayer(){
        if (inventory.HelmetWorn != null && !isSpotFull(helmetSpot)){
            GameObject gl_head = GameObject.Find("head");
            SpriteRenderer glSPR = gl_head.GetComponent<SpriteRenderer>();

            getItemInSpot(helmetSpot).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(helmetSpot).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;
        }
        if (inventory.ChestplateWorn != null && !isSpotFull(chestplateSpot)){
            GameObject gl_torso = GameObject.Find("torso");
            SpriteRenderer glSPR = gl_torso.GetComponent<SpriteRenderer>();

            getItemInSpot(chestplateSpot).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(chestplateSpot).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;
        }
        if (inventory.ShoulderguardWorn != null && !isSpotFull(shoulderguardSpot_right)){
            GameObject gl_right_arm = GameObject.Find("right_arm");
            SpriteRenderer glSPR = gl_right_arm.GetComponent<SpriteRenderer>();

            getItemInSpot(shoulderguardSpot_right).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(shoulderguardSpot_right).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;

            GameObject gl_left_arm = GameObject.Find("left_arm");
            SpriteRenderer glSPR_L = gl_left_arm.GetComponent<SpriteRenderer>();

            getItemInSpot(shoulderguardSpot_left).GetComponent<SpriteRenderer>().sortingLayerName = glSPR_L.sortingLayerName;
            getItemInSpot(shoulderguardSpot_left).GetComponent<SpriteRenderer>().sortingOrder = glSPR_L.sortingOrder + 1;
        }
        if (inventory.WristGuardWorn != null && !isSpotFull(wristGuardSpot_right)){
            GameObject gl_right_forearm = GameObject.Find("right_forearm");
            SpriteRenderer glSPR = gl_right_forearm.GetComponent<SpriteRenderer>();

            getItemInSpot(wristGuardSpot_right).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(wristGuardSpot_right).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;

            GameObject gl_left_forearm = GameObject.Find("left_forearm");
            SpriteRenderer glSPR_L = gl_left_forearm.GetComponent<SpriteRenderer>();

            getItemInSpot(wristGuardSpot_left).GetComponent<SpriteRenderer>().sortingLayerName = glSPR_L.sortingLayerName;
            getItemInSpot(wristGuardSpot_left).GetComponent<SpriteRenderer>().sortingOrder = glSPR_L.sortingOrder + 1;
        }
        if (inventory.PantsWorn != null && !isSpotFull(pantsSpot)){
            GameObject gl_lowertorso = GameObject.Find("lower_torso");
            SpriteRenderer glSPR = gl_lowertorso.GetComponent<SpriteRenderer>();

            getItemInSpot(pantsSpot).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(pantsSpot).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;
        }
        if (inventory.LegGuardWorn != null && !isSpotFull(legGuardSpot_right)){
            GameObject gl_right_leg = GameObject.Find("right_leg");
            SpriteRenderer glSPR = gl_right_leg.GetComponent<SpriteRenderer>();

            getItemInSpot(legGuardSpot_right).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(legGuardSpot_right).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;

            GameObject gl_left_leg = GameObject.Find("left_leg");
            SpriteRenderer glSPR_L = gl_left_leg.GetComponent<SpriteRenderer>();

            getItemInSpot(legGuardSpot_left).GetComponent<SpriteRenderer>().sortingLayerName = glSPR_L.sortingLayerName;
            getItemInSpot(legGuardSpot_left).GetComponent<SpriteRenderer>().sortingOrder = glSPR_L.sortingOrder + 1;
        }
        if (inventory.ShinGuardWorn != null && !isSpotFull(shinGuardSpot_right)){
            GameObject gl_right_calf = GameObject.Find("right_calf");
            SpriteRenderer glSPR = gl_right_calf.GetComponent<SpriteRenderer>();

            getItemInSpot(shinGuardSpot_right).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(shinGuardSpot_right).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;

            GameObject gl_left_calf = GameObject.Find("left_calf");
            SpriteRenderer glSPR_L = gl_left_calf.GetComponent<SpriteRenderer>();

            getItemInSpot(shinGuardSpot_left).GetComponent<SpriteRenderer>().sortingLayerName = glSPR_L.sortingLayerName;
            getItemInSpot(shinGuardSpot_left).GetComponent<SpriteRenderer>().sortingOrder = glSPR_L.sortingOrder + 1;
        }
        if (inventory.ShoesWorn != null && !isSpotFull(shoesSpot_right)){
            GameObject gl_right_foot = GameObject.Find("right_foot");
            SpriteRenderer glSPR = gl_right_foot.GetComponent<SpriteRenderer>();

            getItemInSpot(shoesSpot_right).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(shoesSpot_right).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;

            GameObject gl_left_foot = GameObject.Find("left_foot");
            SpriteRenderer glSPR_L = gl_left_foot.GetComponent<SpriteRenderer>();

            getItemInSpot(shoesSpot_left).GetComponent<SpriteRenderer>().sortingLayerName = glSPR_L.sortingLayerName;
            getItemInSpot(shoesSpot_left).GetComponent<SpriteRenderer>().sortingOrder = glSPR_L.sortingOrder + 1;
        }

        if (inventory.RightHandWorn != null && !isSpotFull(handEquipmentSpot_right)){
            GameObject gl_right_forearm = GameObject.Find("right_forearm");
            SpriteRenderer glSPR = gl_right_forearm.GetComponent<SpriteRenderer>();

            getItemInSpot(handEquipmentSpot_right).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(handEquipmentSpot_right).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;
        }
        if (inventory.LeftHandWorn != null && !isSpotFull(handEquipmentSpot_left)){
            GameObject gl_left_forearm = GameObject.Find("left_forearm");
            SpriteRenderer glSPR = gl_left_forearm.GetComponent<SpriteRenderer>();

            getItemInSpot(handEquipmentSpot_left).GetComponent<SpriteRenderer>().sortingLayerName = glSPR.sortingLayerName;
            getItemInSpot(handEquipmentSpot_left).GetComponent<SpriteRenderer>().sortingOrder = glSPR.sortingOrder + 1;
        }
    }
}
