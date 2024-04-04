using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public int goldBalance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            // Set the Player instance if it doesn't exist yet
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy the duplicate Player instance
            Destroy(gameObject);
            return;
        }

        // Call the initialization method here or any other setup specific to the Player GameObject
        InitPlayer();
    }
}
