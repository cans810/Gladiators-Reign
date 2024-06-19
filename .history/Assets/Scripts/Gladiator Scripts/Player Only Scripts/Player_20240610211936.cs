using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int playerID;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
