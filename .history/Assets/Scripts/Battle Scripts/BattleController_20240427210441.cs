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

        foreach (GameObject enemy in enemies){
            if (enemy.GetComponent<Attributes>() > 0)
            {
                Debug.Log("There are " + enemies.Length + " enemies in the scene.");
            }
            else
            {
                Debug.Log("No enemies found.");
            }
        }
    }
}
