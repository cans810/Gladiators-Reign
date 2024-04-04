using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    
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
    }

    
}
