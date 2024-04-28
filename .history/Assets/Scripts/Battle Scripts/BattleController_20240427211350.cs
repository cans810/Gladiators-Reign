using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject BattleEndCanvas;
    public bool allEnemiesDead;
    private List<GameObject> enemies;

    void Start()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void Update()
    {
        allEnemiesDead = areAllEnemiesDead();

        if (allEnemiesDead)
    }

    public bool areAllEnemiesDead()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null) 
            {
                enemies.Remove(enemy);
            }
            else if (enemy.GetComponent<Attributes>().alive)
            {
                return false;
            }
        }
        return true;
    }
}
