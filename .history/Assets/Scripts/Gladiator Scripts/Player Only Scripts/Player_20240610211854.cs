using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerID;

    private void Awake()
    {

            // Add this player instance to the list and make it persistent
            GameManager.Instance.playerGLs.Add(this.gameObject);
            DontDestroyOnLoad(gameObject);

    }

}
