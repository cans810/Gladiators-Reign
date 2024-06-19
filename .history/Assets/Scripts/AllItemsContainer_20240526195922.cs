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
            DontDestroyOnLoad(gameObject); // Make this object persist across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }
    }

    public List<GameObject> GetAllItems()
    {
        return allItems;
    }
}
