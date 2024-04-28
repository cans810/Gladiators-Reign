using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject BattleEndCanvas;
    public bool allEnemiesDead;
    private List<GameObject> enemies;

    public bool battleHasEnded;

    void Start()
    {
        BattleEndCanvas.SetActive(false);
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void Update()
    {
        allEnemiesDead = areAllEnemiesDead();

        if (allEnemiesDead && !battleHasEnded){
            BattleEndCanvas.SetActive(true);
            battleHasEnded = true;

            // turn players and allies AI off
            Player.Instance.GetComponent<BattleAI>().startAI = false;

            TextMeshProUGUI youWonText = BattleEndCanvas.transform.Find("title").GetComponent<TextMeshProUGUI>();
            youWonText.text = "You prevailed in this battle of life and death.";
        }
        else if (!Player.Instance.GetComponent<Attributes>().alive && !battleHasEnded){
            BattleEndCanvas.SetActive(true);
            battleHasEnded = true;

            // turn enemies AI off
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null && !enemy.GetComponent<Attributes>().alive) 
                {
                    enemy.GetComponent<BattleAI>().startAI = false;
                }
            }

            TextMeshProUGUI youLostText = BattleEndCanvas.transform.Find("title").GetComponent<TextMeshProUGUI>();
            youLostText.text = "You have fallen in this battle of life and death.";
        }
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

    public void GoToTownButton(){
        ScreenFadeController.Instance.FadeToScene("TownScene");
    }
}
