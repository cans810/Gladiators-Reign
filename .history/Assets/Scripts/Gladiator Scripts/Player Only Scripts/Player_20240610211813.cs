using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerID;

    private void Awake()
    {
        // Check if an instance with the same playerID already exists
        Player existingPlayer = GameManager.Instance.playerGLs.Find(p => p.gplayerID == this.playerID);
        if (existingPlayer == null)
        {
            // Add this player instance to the list and make it persistent
            GameManager.Instance.playerGLs.Add(this.gameObject);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy duplicate player instance
            Destroy(gameObject);
        }
    }

}
