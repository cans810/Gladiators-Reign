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

    // Start is called before the first frame update
    void Start()
    {
        // Initialize your items or perform other setup tasks here
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Add other methods to manage allItems list
    public void AddItem(GameObject item)
    {
        allItems.Add(item);
    }

    public void RemoveItem(GameObject item)
    {
        allItems.Remove(item);
    }

    public List<GameObject> GetAllItems()
    {
        return allItems;
    }
}
