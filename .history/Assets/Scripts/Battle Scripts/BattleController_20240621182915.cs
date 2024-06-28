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
        if (!battleHasEnded)
        {
            allEnemiesDead = AreAllEnemiesDead();

            if (allEnemiesDead)
            {
                HandleBattleEnd("You prevailed in this battle of life and death.");
            }
            else if (GameManager.Instance.playerGLs.Exists(p => !p.GetComponent<GLState>().alive))
            {
                HandleBattleEnd("You have fallen in this battle of life and death.");
            }
        }
    }

    private bool AreAllEnemiesDead()
    {
        enemies.RemoveAll(enemy => enemy == null);

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<GLState>().alive)
            {
                return false;
            }
        }

        return true;
    }

    private void HandleBattleEnd(string message)
    {
        BattleEndCanvas.SetActive(true);
        SetButtons();
        battleHasEnded = true;

        foreach (GameObject player in GameManager.Instance.playerGLs)
        {
            var state = player.GetComponent<GLState>();
            if (state != null && state.alive)
            {
                var ai = player.GetComponent<GLBattleAI>();
                ai?.StopAI();

                var animations = player.GetComponent<AnimationsManager>();
                animations?.StopAllAnim();
            }
        }

        foreach (GameObject enemy in enemies)
        {
            var state = enemy.GetComponent<GLState>();
            if (state != null && state.alive)
            {
                var ai = enemy.GetComponent<GLBattleAI>();
                ai?.StopAI();

                var animations = enemy.GetComponent<AnimationsManager>();
                animations?.StopAllAnim();

                //enemy.GetComponent<AnimationsManager>().StartAnim("BeforeFight_1");
            }
        }

        TextMeshProUGUI titleText = BattleEndCanvas.transform.Find("title").GetComponent<TextMeshProUGUI>();
        if (titleText != null)
        {
            titleText.text = message;
        }
    }

    public void SetButtons()
    {
        foreach (Transform child in BattleEndCanvas.transform)
        {
            GameObject button = child.gameObject;

            if (button.name == "GoToDungeonsButton")
            {
                button.SetActive(!GameManager.Instance.completedChapter1);
            }
            else if (button.name == "GoToTownButton")
            {
                button.SetActive(GameManager.Instance.completedChapter1);
            }
        }
    }

    public void GoToTownButton()
    {
        DestroyAllEnemies();
        ScreenFadeController.Instance.FadeToScene("TownScene");
    }

    public void GoToDungeonsButton()
    {
        DestroyAllEnemies();
        StartCoroutine(GameManager.Instance.RecentlyFoughtCoroutine());
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }

    private void DestroyAllEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
