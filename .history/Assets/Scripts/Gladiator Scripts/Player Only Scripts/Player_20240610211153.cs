using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private static List<Player> instances = new List<Player>();

    public int playerID;

    private void Awake()
    {
        // Check if an instance with the same playerID already exists
        Player existingPlayer = instances.Find(p => p.playerID == this.playerID);
        if (existingPlayer == null)
        {
            // Add this player instance to the list and make it persistent
            instances.Add(this);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy duplicate player instance
            Destroy(gameObject);
        }
    }

    // Optionally, you can add more player-specific logic here
}
