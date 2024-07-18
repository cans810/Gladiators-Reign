using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodreaverActions : MonoBehaviour
{
    public GladiatorManager glManager;
    public GLCommonActions commonActions;
    public GLBattleAI AI;

    public void Start(){
        glManager = GetComponent<GladiatorManager>();

        commonActions = glManager.commonActions;
    }

    public void AddSkill(string skillName){
        AI.boolActionsDict.Add(skillName,false);

        AI.actionsList.Add(skillName);
    }

    public void BloodreaverAI(){

        int randomAction = UnityEngine.Random.Range(0, AI.boolActionsDict.Count);

        if (AI.actionsList[randomAction] != "GetKilled")
        {
            AI.actionQueue.Enqueue("BloodreaverActions", AI.actionsList[randomAction], true, false);
        }

    }

    
    // ravagers cleave attack methods start
    public void RavagersCleaveAttackMelee(){
        if (glManager.battleAI.currentEnemyChosen != null && glManager.state.alive){
            glManager.animationsManager.StartAction("AttackMelee_1");
        }
        else{
            StopRavagersCleaveAttackMelee();
        }
    }

    public void WalkTo_RavagersCleaveAttack(){
        glManager.battleAI.currentEnemyChosen = commonActions.FindNearestEnemy();

        StartCoroutine(WalkTo_RavagersCleaveAttack_Coroutine());
    }

    IEnumerator WalkTo_RavagersCleaveAttack_Coroutine()
    {
        glManager.animationsManager.StartAction("Walk");
        glManager.battleAI.boolActionsDict["BloodReaver_WalkTo_RavagersCleaveAttack"] = true;

        glManager.battleAI.targetWalkPos = commonActions.ImproveTargetPos(glManager.battleAI.currentEnemyChosen.transform.position);

        Vector2 direction = (glManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

        while (!hasArrivedTo_RavagersCleaveAttack(glManager.battleAI.targetWalkPos) && glManager.battleAI.boolActionsDict["BloodReaver_WalkTo_RavagersCleaveAttack"] == true 
        && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)
        {
            glManager.battleAI.targetWalkPos = commonActions.ImproveTargetPos(glManager.battleAI.currentEnemyChosen.transform.position);

            direction = (glManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

            yield return null; // Wait for the next frame
        }

        glManager.animationsManager.StopAction("Walk");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (glManager.battleAI.boolActionsDict["BloodReaver_WalkTo_RavagersCleaveAttack"] == true 
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

    public void StopRavagersCleaveAttackMelee(){
        glManager.animationsManager.StopAction("AttackMelee_1");
        glManager.battleAI.boolActionsDict["BloodReaver_WalkTo_RavagersCleaveAttack"] = false;

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
