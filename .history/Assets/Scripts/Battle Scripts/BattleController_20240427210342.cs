using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckEnemiesStatus()
{
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    if (enemies.Length > 0)
    {
        Debug.Log("There are " + enemies.Length + " enemies in the scene.");
    }
    else
    {
        // There are no enemies in the scene
        Debug.Log("No enemies found.");
        // Add your logic for no enemies (e.g., no enemies to fight, victory condition)
    }
}
}
