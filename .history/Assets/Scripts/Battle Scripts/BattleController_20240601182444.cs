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
            SetButtons();

            battleHasEnded = true;

            // turn players and allies AI off
            Player.Instance.gameObject.GetComponent<BattleAI>().StopAI();
            Player.Instance.

            TextMeshProUGUI youWonText = BattleEndCanvas.transform.Find("title").gameObject.GetComponent<TextMeshProUGUI>();
            youWonText.text = "You prevailed in this battle of life and death.";
        }
        else if (!Player.Instance.GetComponent<Attributes>().alive && !battleHasEnded){
            BattleEndCanvas.SetActive(true);
            SetButtons();
            battleHasEnded = true;

            // turn enemies AI off
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null && enemy.GetComponent<Attributes>().alive) 
                {
                    enemy.GetComponent<BattleAI>().StopAI();
                }
            }

            TextMeshProUGUI youLostText = BattleEndCanvas.transform.Find("title").gameObject.GetComponent<TextMeshProUGUI>();
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

    public void SetButtons()
    {
        foreach (Transform child in BattleEndCanvas.transform)
        {
            GameObject button = child.gameObject;

            if (button.name == "GoToDungeonsButton"){
                if (GameManager.Instance.completedChapter1){
                    button.gameObject.SetActive(false);
                }
                else{
                    button.gameObject.SetActive(true);
                }
            }

            else if (button.name == "GoToTownButton"){
                if (GameManager.Instance.completedChapter1){
                    button.gameObject.SetActive(true);
                }
                else{
                    button.gameObject.SetActive(false);
                }
            }
        }
    }

    public void GoToTownButton(){
        destroyAllEnemies();

        ScreenFadeController.Instance.FadeToScene("TownScene");
    }

    public void GoToDungeonsButton(){
        destroyAllEnemies();

        StartCoroutine(GameManager.Instance.RecentlyFoughtCoroutine());

        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }

    public void destroyAllEnemies(){
        foreach (GameObject enemy in enemies) {
            Destroy(enemy);
        }
    }
}
