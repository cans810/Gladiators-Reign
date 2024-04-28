using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    
    private void Awake()
    {

            DontDestroyOnLoad(gameObject);
        
        else
        {
            // Destroy the duplicate Player instance
            Destroy(gameObject);
            return;
        }
    }

}
