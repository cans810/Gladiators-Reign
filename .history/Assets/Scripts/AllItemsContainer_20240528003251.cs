using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItemsContainer : MonoBehaviour
{
    public static AllItemsContainer Instance { get; private set; }

    public List<GameObject> allHelmets = new List<GameObject>();

    public List<GameObject> allChestplates = new List<GameObject>();

    public List<GameObject> allShoulderguards = new List<GameObject>();

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
        foreach (GameObject item in allChestplates){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
        return null;
    }
}
