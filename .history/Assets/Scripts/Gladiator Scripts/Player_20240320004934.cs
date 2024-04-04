using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    Rigidbody2D rb;
    
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

        rb = GetComponent<Rigidbody2D>();
    }

    public void Update(){
        if (SceneManager.GetActiveScene().name.Equals("GladiatorCreationScene")){
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            transform.position = new Vector3(0,-6.264662f,0);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
