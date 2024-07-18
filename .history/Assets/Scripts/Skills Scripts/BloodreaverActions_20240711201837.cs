using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodreaverActions : MonoBehaviour
{
    public GladiatorManager glManager;
    public GLCommonActions commonActions;

    public void Start(){
        glManager = GetComponent<GladiatorManager>();

        commonActions = glManager.commonActions;
    }

    public void AttackMelee(){
        if (glManager.battleAI.currentEnemyChosen != null && glManager.state.alive){
            glManager.animationsManager.StartAction("AttackMelee_1");
        }
        else{
            StopAttackMelee();
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

        while (!hasArrivedToAttack(glManager.battleAI.targetWalkPos) && glManager.battleAI.boolActionsDict["BloodReaver_WalkTo_RavagersCleaveAttack"] == true 
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
            AttackMelee();
        }
        else{
            StopAttackMelee();
        }
    }


    public void DamageMelee(){
        if (glManager.HitBox.objectsInHitbox.Contains(glManager.battleAI.currentEnemyChosen)){
            if (glManager.battleAI.currentEnemyChosen != null && !glManager.battleAI.currentEnemyChosen.GetComponent<GLBattleAI>().boolActionsDict["TakeGuard"] 
            && (!glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)){
                int hpBefore = (int)glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP;
                glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP -= 1;
                glManager.battleAI.currentEnemyChosen.GetComponent <GLAttributes>().amount_GotHit = hpBefore - glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP;

                glManager.battleAI.currentEnemyChosen.GetComponent<GladiatorManager>().PopupsManager.GetComponent<PopUpsManager>().HitPopUp(glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().amount_GotHit
                ,glManager.battleAI.currentEnemyChosen);
                
                StartCoroutine(OpponentGotHitCoroutine(glManager.battleAI.currentEnemyChosen));
            }
            else if(glManager.battleAI.currentEnemyChosen != null && glManager.battleAI.currentEnemyChosen.GetComponent<GLBattleAI>().boolActionsDict["TakeGuard"]){
                Debug.Log("enemy is blocking.");
            }
            else if (glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().dying || !glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive){
                //Debug.Log("enemy dead or dying");
                StopAttackMelee();
            }
        }
        else{
            Debug.Log("attack missed.");
        }
    }

    IEnumerator OpponentGotHitCoroutine(GameObject opponent){

        opponent.GetComponent<GLState>().gotHit = true;
        
        if (!opponent.GetComponent<GLState>().dying || opponent.GetComponent<GLState>().alive){
            yield return new WaitForSeconds(3f);
        }
        else{
            StopCoroutine(OpponentGotHitCoroutine(opponent));
        }

        opponent.GetComponent<GLState>().gotHit = false;
    }

    public void StopAttackMelee(){
        glManager.animationsManager.StopAction("AttackMelee_1");
        glManager.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = false;

        //attributes.battleAI.currentEnemyChosen = null;
    }

    public bool hasArrivedToAttack(Vector2 targetPos){
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
}
