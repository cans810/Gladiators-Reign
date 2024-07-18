using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodreaverActions : MonoBehaviour
{
    public GladiatorManager glManager;
    public GLCommonActions commonActions;
    public GLBattleAI AI;

    public Dictionary<string,bool> boolActionsDict;
    public List<string> actionsList;

    public void Start(){
        glManager = GetComponent<GladiatorManager>();

        commonActions = glManager.commonActions;
        AI = glManager.battleAI;

        boolActionsDict = new Dictionary<string, bool>();

        actionsList = new List<string>();
    }

    public void AddSkill(string skillName){
        boolActionsDict.Add(skillName,false);

        actionsList.Add(skillName);
    }

    public void BloodreaverAI()
    {
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
            } while (forbiddenActions.Contains(randomActionChosen)); // Repeat until a valid action is chosen

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
    public void Bloodreaver_RavagersCleave(){
        // skill popup
        GameObject popupCanvas = GameObject.Find("UsedSkillsCanvas");
        GameObject skillPopup = Instantiate(glManager.skillPopupPrefab,)

        glManager.battleAI.currentEnemyChosen = commonActions.FindNearestEnemy();

        StartCoroutine(WalkTo_RavagersCleaveAttack_Coroutine());
    }

    IEnumerator WalkTo_RavagersCleaveAttack_Coroutine()
    {
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
        && (!glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)){
            RavagersCleaveAttackMelee();
        }
        else{
            StopRavagersCleaveAttackMelee();
        }
    }


    public void DamageMelee_RavagersCleaveAttack(){
        if (glManager.HitBox.objectsInHitbox.Contains(glManager.battleAI.currentEnemyChosen)){
            if (glManager.battleAI.currentEnemyChosen != null && !glManager.battleAI.currentEnemyChosen.GetComponent<GLBattleAI>().boolActionsDict["TakeGuard"] 
            && (!glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)){
                int hpBefore = (int)glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP;
                glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP -= 1;
                glManager.battleAI.currentEnemyChosen.GetComponent <GLAttributes>().amount_GotHit = hpBefore - glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP;

                glManager.battleAI.currentEnemyChosen.GetComponent<GladiatorManager>().PopupsManager.GetComponent<PopUpsManager>().HitPopUp(glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().amount_GotHit
                ,glManager.battleAI.currentEnemyChosen);
                
                StartCoroutine(commonActions.OpponentGotHitCoroutine(glManager.battleAI.currentEnemyChosen));
            }
            else if(glManager.battleAI.currentEnemyChosen != null && glManager.battleAI.currentEnemyChosen.GetComponent<GLBattleAI>().boolActionsDict["TakeGuard"]){
                Debug.Log("enemy is blocking.");
            }
            else if (glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying || !glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive){
                //Debug.Log("enemy dead or dying");
                StopRavagersCleaveAttackMelee();
            }
        }
        else{
            Debug.Log("attack missed.");
        }
    }

    public void RavagersCleaveAttackMelee(){
        if (glManager.battleAI.currentEnemyChosen != null && glManager.state.alive){
            glManager.animationsManager.StartAction("RavagersCleave");
        }
        else{
            StopRavagersCleaveAttackMelee();
        }
    }

    public void StopRavagersCleaveAttackMelee(){
        glManager.animationsManager.StopAction("RavagersCleave");
        glManager.battleAI.boolActionsDict["Bloodreaver_RavagersCleave"] = false;

        //attributes.battleAI.currentEnemyChosen = null;
    }

    public bool hasArrivedTo_RavagersCleaveAttack(Vector2 targetPos){
        float distanceToTarget = Vector2.Distance(transform.position, targetPos);

        if (distanceToTarget <= 1f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return true;
        }
        else{
            return false;
        }
    }

    // ravagers cleave attack methods finish
}
