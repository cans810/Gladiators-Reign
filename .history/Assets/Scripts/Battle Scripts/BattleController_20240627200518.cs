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

    public RewardsManager RewardsManager;

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
                StartCoroutine(HandleBattleEnd("You prevailed in this battle of life and death."));
            }
            else if (GameManager.Instance.playerGLs.Exists(p => !p.GetComponent<GLState>().alive))
            {
                StartCoroutine(HandleBattleEnd("You have fallen in this battle of life and death."));
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

    private IEnumerator HandleBattleEnd(string message,)
    {
        SetButtons();
        battleHasEnded = true;

        List<Coroutine> animationCoroutines = new List<Coroutine>();

        foreach (GameObject player in GameManager.Instance.playerGLs)
        {
            var state = player.GetComponent<GLState>();
            if (state != null && state.alive)
            {
                var ai = player.GetComponent<GLBattleAI>();
                ai?.StopAI();

                var animations = player.GetComponent<AnimationsManager>();
                if (animations != null)
                {
                    animations.StopAllAnim();
                    animations.PlayCurrentAnimation();
                    animationCoroutines.Add(StartCoroutine(WaitForAnimationToEnd(animations, "Idle")));
                }
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
                if (animations != null)
                {
                    animations.StopAllAnim();
                    animations.PlayCurrentAnimation();
                    animationCoroutines.Add(StartCoroutine(WaitForAnimationToEnd(animations, "Idle")));
                }
            }
        }

        foreach (var coroutine in animationCoroutines)
        {
            yield return coroutine;
        }

        BattleEndCanvas.SetActive(true);
        TextMeshProUGUI titleText = BattleEndCanvas.transform.Find("BattleInfo").transform.Find("title").GetComponent<TextMeshProUGUI>();
        if (titleText != null)
        {
            titleText.text = message;
        }

        BattleEndCanvas.GetComponent<Animator>().SetBool("BattleEnd",true);
    }

    private IEnumerator WaitForAnimationToEnd(AnimationsManager animations, string nextAnimation)
    {
        while (animations.IsAnimationPlaying())
        {
            yield return null;
        }
        animations.StartAnim(nextAnimation);
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
