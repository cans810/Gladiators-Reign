using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItemsContainer : MonoBehaviour
{
    public static AllItemsContainer Instance { get; private set; }

    private List<GameObject> allItems = new List<GameObject>();

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

    public GameObject GetItem(string itemName)
    {
        foreach (GameObject item in allItems){
            if (item.GetComponent<Item>().itemName == itemName){
                return item;
            }
        }
    }
}
