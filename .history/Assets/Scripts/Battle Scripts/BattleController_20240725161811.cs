using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject BattleEndCanvas;
    public bool allEnemiesDead;
    public List<GameObject> players;
    public List<GameObject> enemies;
    public bool battleHasEnded;

    public RewardsManager RewardsManager;

    void Start()
    {
        BattleEndCanvas.SetActive(false);

        players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void Update()
    {
        if (!battleHasEnded)
        {
            allEnemiesDead = AreAllEnemiesDead();

            if (allEnemiesDead)
            {
                StartCoroutine(HandleBattleEnd("You prevailed in this battle of life and death.", true));
            }
            else if (GameManager.Instance.playerGLs.Exists(p => !p.GetComponent<GLState>().alive))
            {
                StartCoroutine(HandleBattleEnd("You have fallen in this battle of life and death.", false));
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

    private IEnumerator HandleBattleEnd(string message, bool won)
    {
        SetButtons();
        battleHasEnded = true;
        DungeonHomeController.sceneMode = "";

        List<Coroutine> animationCoroutines = new List<Coroutine>();

        foreach (GameObject player in players)
        {
            var state = player.GetComponent<GLState>();
            if (state != null)
            {
                var ai = player.GetComponent<GLBattleAI>();
                ai.StopAI();

                var animations = player.GetComponent<AnimationsManager>();
                if (animations != null)
                {
                    if (state.alive)
                    {
                        animations.StopAllAnim();
                        animations.PlayCurrentAnimation();
                        animationCoroutines.Add(StartCoroutine(WaitForAnimationToEnd(animations, "Idle", state)));
                    }
                    else
                    {
                        // For dead players, just wait for the current (death) animation to finish
                        animationCoroutines.Add(StartCoroutine(WaitForAnimationToEnd(animations, null, state)));
                    }
                }
            }
        }

        foreach (GameObject enemy in enemies)
        {
            var state = enemy.GetComponent<GLState>();
            if (state != null)
            {
                var ai = enemy.GetComponent<GLBattleAI>();
                ai.StopAI();

                var animations = enemy.GetComponent<AnimationsManager>();
                if (animations != null)
                {
                    if (state.alive)
                    {
                        animations.StopAllAnim();
                        animations.PlayCurrentAnimation();
                        animationCoroutines.Add(StartCoroutine(WaitForAnimationToEnd(animations, "Idle", state)));
                    }
                    else
                    {
                        // For dead enemies, just wait for the current (death) animation to finish
                        animationCoroutines.Add(StartCoroutine(WaitForAnimationToEnd(animations, null, state)));
                    }
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

        BattleEndCanvas.GetComponent<Animator>().SetBool("BattleEnd", true);

        if (won){
            RewardsManager.rewardWithCoins();
            RewardsManager.rewardWithItem();
            RewardsManager.rewardWithGladiator(enemies[0]);
        }
    }

    private IEnumerator WaitForAnimationToEnd(AnimationsManager animations, string nextAnimation, GLState state)
    {
        while (animations.IsAnimationPlaying())
        {
            yield return null;
        }
        if (nextAnimation != null && state.alive)
        {
            animations.StartAnim(nextAnimation);
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

    public void GoToDungeonsButton()
    {
        StartCoroutine(GameManager.Instance.RecentlyFoughtCoroutine());

        GameManager.Instance.playerInventory.Add(RewardsManager.getRewardItem());

        GameManager.Instance.playerGLs.Add(RewardsManager.getRewardGladiator());

        GameManager.Instance.coins += RewardsManager.getRewardCoin();

        DestroyAllEnemiesExceptRewardedGl();

        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }

    private void DestroyAllEnemiesExceptRewardedGl()
    {
        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            if (enemies[i] != RewardsManager.getRewardGladiator())
            {
                Destroy(enemies[i]);
            }
        }
    }
}