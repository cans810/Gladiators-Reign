using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodreaverActions : MonoBehaviour
{
    public GladiatorManager glManager;
    public GLCommonActions commonActions;
    public GLBattleAI AI;

    public Dictionary<string, bool> boolActionsDict;
    public List<string> actionsList;

    // 1) RAVAGERS CLEAVE ATTRIBUTES
    public Sprite ravagerscleaveTexture;
    public bool canUse_RavagersCleave = true; // Initialize to true so the skill can be used at the start

    private void Start()
    {
        glManager = GetComponent<GladiatorManager>();

        if (glManager == null)
        {
            Debug.LogError("GladiatorManager component not found!");
            return;
        }

        commonActions = glManager.commonActions;
        AI = glManager.battleAI;

        if (commonActions == null || AI == null)
        {
            Debug.LogError("Required components not found!");
            return;
        }

        boolActionsDict = new Dictionary<string, bool>();
        actionsList = new List<string>();
    }

    public void AddSkill(string skillName)
    {
        if (!boolActionsDict.ContainsKey(skillName))
        {
            boolActionsDict.Add(skillName, false);
            actionsList.Add(skillName);
        }
    }

    public void BloodreaverAI()
    {
        if (boolActionsDict == null || actionsList == null)
        {
            Debug.LogError("Actions dictionary or list not initialized!");
            return;
        }

        int randomAI = UnityEngine.Random.Range(0, 2);
        int randomAction;
        string randomActionChosen = "";

        // List of actions to avoid
        List<string> forbiddenActions = new List<string> { "", "GetKilled" };

        if (randomAI == 0 && boolActionsDict.Count != 0)
        {
            do
            {
                randomAction = UnityEngine.Random.Range(0, boolActionsDict.Count);
                randomActionChosen = actionsList[randomAction];
            } while (forbiddenActions.Contains(randomActionChosen) || (randomActionChosen == "Bloodreaver_RavagersCleave" && !canUse_RavagersCleave)); // Check cooldown here

            AI.actionQueue.Enqueue("BloodreaverActions", randomActionChosen, true, false);
        }
        else
        {
            do
            {
                randomAction = UnityEngine.Random.Range(0, AI.boolActionsDict.Count);
                randomActionChosen = AI.actionsList[randomAction];
            } while (forbiddenActions.Contains(randomActionChosen)); // Repeat until a valid action is chosen

            AI.actionQueue.Enqueue("GLCommonActions", randomActionChosen, true, false);
        }
    }

    // ravagers cleave attack methods start
    public void Bloodreaver_RavagersCleave()
    {
        if (!canUse_RavagersCleave)
        {
            Debug.Log("Ravager's Cleave is on cooldown.");
            return; // Exit if the skill is on cooldown
        }

        if (glManager == null || glManager.battleAI == null || commonActions == null)
        {
            Debug.LogError("Required components are not initialized.");
            return;
        }

        glManager.battleAI.currentEnemyChosen = commonActions.FindNearestEnemy();

        if (glManager.battleAI.currentEnemyChosen == null)
        {
            Debug.LogError("No enemy found for Ravager's Cleave.");
            return;
        }

        StartCoroutine(WalkTo_RavagersCleaveAttack_Coroutine());
        StartCoroutine(SetRavagersCleaveCooldown(10f)); // 10 seconds cooldown
    }

    private IEnumerator WalkTo_RavagersCleaveAttack_Coroutine()
    {
        if (glManager == null || glManager.animationsManager == null || glManager.battleAI == null)
        {
            yield break; // Exit coroutine if components are not initialized
        }

        glManager.animationsManager.StartAction("Walk");
        glManager.battleAI.boolActionsDict["Bloodreaver_RavagersCleave"] = true;

        glManager.battleAI.targetWalkPos = commonActions.ImproveTargetPos(glManager.battleAI.currentEnemyChosen.transform.position);

        Vector2 direction = (glManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

        while (!hasArrivedTo_RavagersCleaveAttack(glManager.battleAI.targetWalkPos) && glManager.battleAI.boolActionsDict["Bloodreaver_RavagersCleave"] == true
            && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)
        {
            glManager.battleAI.targetWalkPos = commonActions.ImproveTargetPos(glManager.battleAI.currentEnemyChosen.transform.position);

            direction = (glManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

            yield return null; // Wait for the next frame
        }

        glManager.animationsManager.StopAction("Walk");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (glManager.battleAI.boolActionsDict["Bloodreaver_RavagersCleave"] == true
            && (!glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive))
        {
            RavagersCleaveAttackMelee();
        }
        else
        {
            StopRavagersCleaveAttackMelee();
        }
    }

    public void DamageMelee_RavagersCleaveAttack()
    {
        if (glManager.HitBox.objectsInHitbox.Contains(glManager.battleAI.currentEnemyChosen))
        {
            if (glManager.battleAI.currentEnemyChosen != null && !glManager.battleAI.currentEnemyChosen.GetComponent<GLBattleAI>().boolActionsDict["TakeGuard"]
                && (!glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive))
            {
                int hpBefore = (int)glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP;
                glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP -= glManager.attributes.meleeDMG * 1.5f; // %150 times more hit dmg
                glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().amount_GotHit = hpBefore - glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP;

                glManager.battleAI.currentEnemyChosen.GetComponent<GladiatorManager>().PopupsManager.GetComponent<PopUpsManager>().HitPopUp(glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().amount_GotHit
                    , glManager.battleAI.currentEnemyChosen);

                StartCoroutine(commonActions.OpponentGotHitCoroutine(glManager.battleAI.currentEnemyChosen));
            }
            else if (glManager.battleAI.currentEnemyChosen != null && glManager.battleAI.currentEnemyChosen.GetComponent<GLBattleAI>().boolActionsDict["TakeGuard"])
            {
                Debug.Log("enemy is blocking.");
            }
            else if (glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying || !glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)
            {
                //Debug.Log("enemy dead or dying");
                StopRavagersCleaveAttackMelee();
            }
        }
        else
        {
            Debug.Log("attack missed.");
        }
    }

    public void RavagersCleaveAttackMelee()
    {
        if (glManager.battleAI.currentEnemyChosen != null && glManager.state.alive)
        {
            glManager.animationsManager.StartAction("RavagersCleave");
        }
        else
        {
            StopRavagersCleaveAttackMelee();
        }
    }

    public void StopRavagersCleaveAttackMelee()
    {
        glManager.animationsManager.StopAction("RavagersCleave");
        glManager.battleAI.boolActionsDict["Bloodreaver_RavagersCleave"] = false;

        //attributes.battleAI.currentEnemyChosen = null;
    }

    public bool hasArrivedTo_RavagersCleaveAttack(Vector2 targetPos)
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetPos);

        if (distanceToTarget <= 1f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator SetRavagersCleaveCooldown(float seconds)
    {
        canUse_RavagersCleave = false;

        yield return new WaitForSeconds(seconds);

        canUse_RavagersCleave = true;
    }

    // ravagers cleave attack methods finish
}
