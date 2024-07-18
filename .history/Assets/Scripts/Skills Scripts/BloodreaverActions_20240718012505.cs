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

    // 1) RAVAGERS CLEAVE ATTRIBUTES
    public Sprite ravagerscleaveTexture;
    public bool canUse_RavagersCleave;
    public bool canUse_GrimChallenge;
    public bool canUse_FrenziedAssault;
    public bool canUse_FrenziedAssault;

    public void Start(){
        glManager = GetComponent<GladiatorManager>();

        commonActions = glManager.commonActions;
        AI = glManager.battleAI;

        boolActionsDict = new Dictionary<string, bool>();

        actionsList = new List<string>();

        canUse_RavagersCleave = true;
        canUse_GrimChallenge = true;
        canUse_FrenziedAssault = true;
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
        //GameObject popupCanvas = GameObject.Find("UsedSkillsCanvas");
        //GameObject skillPopup = Instantiate(glManager.skillPopupPrefab, popupCanvas.transform);
        //skillPopup.GetComponent<SkillPopUp>().InitSkillPopup("Ravager's Cleave",ravagerscleaveTexture);

        // check for cooldown
        if (canUse_RavagersCleave){
            if (!glManager.state.effectedBy_GrimChallenge){
                glManager.battleAI.currentEnemyChosen = commonActions.FindNearestEnemy();
            }

            StartCoroutine(WalkTo_RavagersCleaveAttack_Coroutine());

            StartCoroutine(SetRavagersCleaveCooldown(10f)); // 10 seconds cooldown
        }
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
                glManager.battleAI.currentEnemyChosen.GetComponent<GLAttributes>().HP -= glManager.attributes.meleeDMG * 1.5f; // %150 times more hit dmg
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

    public IEnumerator SetRavagersCleaveCooldown(float seconds){
        canUse_RavagersCleave = false;

        yield return new WaitForSeconds(seconds);

        canUse_RavagersCleave = true;
    }

    // ravagers cleave attack methods finish


    // grim challenge methods start
    public void Bloodreaver_GrimChallenge(){
        // skill popup
        //GameObject popupCanvas = GameObject.Find("UsedSkillsCanvas");
        //GameObject skillPopup = Instantiate(glManager.skillPopupPrefab, popupCanvas.transform);
        //skillPopup.GetComponent<SkillPopUp>().InitSkillPopup("Ravager's Cleave",ravagerscleaveTexture);

        // check for cooldown
        if (canUse_GrimChallenge){
            glManager.battleAI.currentEnemyChosen = commonActions.FindNearestEnemy();

            glManager.battleAI.currentEnemyChosen.GetComponent<GLBattleAI>().currentEnemyChosen = gameObject;

            glManager.animationsManager.StartAction("GrimChallenge");

            StartCoroutine(SetGrimChallengeCooldown(15f)); // 15 seconds cooldown

            StartCoroutine(GrimChallengeEffectCoroutine());
        }
    }

    public IEnumerator GrimChallengeEffectCoroutine(){
        glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().effectedBy_GrimChallenge = true;
        glManager.battleAI.boolActionsDict["Bloodreaver_GrimChallenge"] = true;

        yield return new WaitForSeconds(8f);

        glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().effectedBy_GrimChallenge = false;
    }

    public IEnumerator SetGrimChallengeCooldown(float seconds){
        canUse_GrimChallenge = false;

        yield return new WaitForSeconds(seconds);

        canUse_GrimChallenge = true;
    }

    public void StopGrimChallengeAnim(){
        glManager.animationsManager.StopAction("GrimChallenge");
        glManager.battleAI.boolActionsDict["Bloodreaver_GrimChallenge"] = false;
    }

    // grim challenge methods finish



    // frenzied assault methods start
    public void Bloodreaver_FrenziedAssault(){
        // skill popup
        //GameObject popupCanvas = GameObject.Find("UsedSkillsCanvas");
        //GameObject skillPopup = Instantiate(glManager.skillPopupPrefab, popupCanvas.transform);
        //skillPopup.GetComponent<SkillPopUp>().InitSkillPopup("Ravager's Cleave",ravagerscleaveTexture);

        // check for cooldown
        if (canUse_FrenziedAssault){
            glManager.battleAI.currentEnemyChosen = commonActions.FindNearestEnemy();

            glManager.animationsManager.StartAction("FrenziedAssault");

            StartCoroutine(SetFrenziedAssaultCooldown(20f)); // 20 seconds cooldown

            StartCoroutine(FrenziedAssaultEffectCoroutine());
        }
    }

    public IEnumerator FrenziedAssaultEffectCoroutine()
    {
        glManager.battleAI.boolActionsDict["Bloodreaver_FrenziedAssault"] = true;

        float meleeDmgBefore = glManager.attributes.meleeDMG;

        glManager.attributes.meleeDMG = glManager.attributes.meleeDMG * 130 / 100;

        float duration = 10f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            if (IsAnimationPlaying("AttackMelee_1"))
            {
                glManager.SetAnimationSpeed("AttackMelee_1", 1.2f);
            }
            else
            {
                glManager.SetAnimationSpeed("AttackMelee_1", 1f);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        glManager.attributes.meleeDMG = meleeDmgBefore;
        glManager.SetAnimationSpeed("AttackMelee_1", 1);
    }

    private bool IsAnimationPlaying(string animationName)
    {
        AnimatorClipInfo[] clipInfo = glManager.animator.GetCurrentAnimatorClipInfo(0);
        foreach (AnimatorClipInfo clip in clipInfo)
        {
            if (clip.clip.name == animationName)
            {
                return true;
            }
        }
        return false;
    }

    public IEnumerator SetFrenziedAssaultCooldown(float seconds){
        canUse_FrenziedAssault = false;

        yield return new WaitForSeconds(seconds);

        canUse_FrenziedAssault = true;
    }

    public void StopFrenziedAssaultAnim(){
        glManager.animationsManager.StopAction("FrenziedAssault");
        glManager.battleAI.boolActionsDict["Bloodreaver_FrenziedAssault"] = false;
    }

    // frenzied assault methods finish
}
