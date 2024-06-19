using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItemsContainer : MonoBehaviour
{
    public static AllItemsContainer Instance { get; private set; }

    public List<GameObject> allArmors = new List<GameObject>();
    public List<GameObject> allHelmets = new List<GameObject>();
    public List<GameObject> allChestplates = new List<GameObject>();
    public List<GameObject> allShoulderguards = new List<GameObject>();
    public List<GameObject> allWristGuards = new List<GameObject>();
    public List<GameObject> allPants = new List<GameObject>();
    public List<GameObject> allLegGuards = new List<GameObject>();
    public List<GameObject> allShinGuards = new List<GameObject>();
    public List<GameObject> allShoes = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        allArmors.AddRange(Instance.allHelmets);
        allArmors.AddRange(Instance.allChestplates);
        allArmors.AddRange(Instance.allShoulderguards);
        allArmors.AddRange(Instance.allWristGuards);
        allArmors.AddRange(Instance.allPants);
        allArmors.AddRange(Instance.allPants);

    }

    public GameObject GetHelmet(string itemName)
    {
        foreach (GameObject item in allHelmets){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }

    public GameObject GetChestplate(string itemName)
    {
        foreach (GameObject item in allChestplates){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }

    public GameObject GetShoulderguard(string itemName)
    {
        foreach (GameObject item in allShoulderguards){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }

    public GameObject GetWristguard(string itemName)
    {
        foreach (GameObject item in allWristGuards){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }

    public GameObject GetPant(string itemName)
    {
        foreach (GameObject item in allPants){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }

    public GameObject GetLegGuard(string itemName)
    {
        foreach (GameObject item in allLegGuards){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }

    public GameObject GetShinGuard(string itemName)
    {
        foreach (GameObject item in allShinGuards){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }

    public GameObject GetShoe(string itemName)
    {
        foreach (GameObject item in allShoes){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }
}
