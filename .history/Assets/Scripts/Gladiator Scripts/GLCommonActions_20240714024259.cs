using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLCommonActions : MonoBehaviour
{
    public GladiatorManager glManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        if (glManager != null && glManager.state.alive && glManager.battleAI.startAI){
            if (glManager.battleAI.currentEnemyChosen != null){
                faceTowardsEnemy(glManager.battleAI.currentEnemyChosen.transform.position);
            }
        }
    }

    public void AttackMelee(){
        if (glManager.battleAI.currentEnemyChosen != null && glManager.state.alive){
            glManager.animationsManager.StartAction("AttackMelee_1");
        }
        else{
            StopAttackMelee();
        }
    }

    public void WalkToPointMeleeAttack(){
        glManager.battleAI.currentEnemyChosen = FindNearestEnemy();

        StartCoroutine(WalkToPointMeleeAttackCoroutine());
    }

    IEnumerator WalkToPointMeleeAttackCoroutine()
    {
        glManager.animationsManager.StartAction("Walk");
        glManager.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = true;

        glManager.battleAI.targetWalkPos = ImproveTargetPos(glManager.battleAI.currentEnemyChosen.transform.position);

        Vector2 direction = (glManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

        while (!hasArrivedToAttack(glManager.battleAI.targetWalkPos) && glManager.battleAI.boolActionsDict["WalkToPointMeleeAttack"] == true 
        && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)
        {
            glManager.battleAI.targetWalkPos = ImproveTargetPos(glManager.battleAI.currentEnemyChosen.transform.position);

            direction = (glManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

            yield return null; // Wait for the next frame
        }

        glManager.animationsManager.StopAction("Walk");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (glManager.battleAI.boolActionsDict["WalkToPointMeleeAttack"] == true 
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

    public IEnumerator OpponentGotHitCoroutine(GameObject opponent){

        opponent.GetComponent<GLState>().gotHit = true;

        // blood splash effect
        glManager.gLEffectsManager.BloodSpashEffect(glManager.GetBodyPartPos);
        
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

    public void KeepDistance(){
        glManager.battleAI.currentEnemyChosen = FindNearestEnemy();

        StartCoroutine(KeepDistanceCoroutine());
    }

    IEnumerator KeepDistanceCoroutine()
    {
        glManager.animationsManager.StartAction("Walk");
        glManager.battleAI.boolActionsDict["KeepDistance"] = true;

        Vector2 enemyPosition = glManager.battleAI.currentEnemyChosen.transform.position;

        float randomDistance = UnityEngine.Random.Range(1f, 2f);

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 targetPosition = enemyPosition + randomDirection * randomDistance;

        targetPosition = ImproveTargetPos(targetPosition);

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

        while (!hasArrivedToWalkDest(targetPosition) && glManager.battleAI.boolActionsDict["KeepDistance"] == true
        && glManager.battleAI.currentEnemyChosen.GetComponent<GLState>().alive)
        {
            direction = (targetPosition - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * GetComponent<GLAttributes>().WalkSpeed;

            yield return null; // Wait for the next frame
        }

        // Stop keeping distance
        StopKeepDistance();
    }

    public void StopKeepDistance(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        glManager.animationsManager.StopAction("Walk");
        glManager.battleAI.boolActionsDict["KeepDistance"] = false;
    }

    public bool hasArrivedToWalkDest(Vector2 targetPos){
        float distanceToTarget = Vector2.Distance(transform.position, targetPos);

        if (distanceToTarget <= 0.05f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return true;
        }
        else{
            return false;
        }
    }

    public void TakeGuard(){
        StartCoroutine(TakeGuardCoroutine());
    }

    IEnumerator TakeGuardCoroutine() 
    {
        glManager.animationsManager.StartAction("TakeGuard");
        glManager.battleAI.boolActionsDict["TakeGuard"] = true;

        float elapsedTime = 0f;
        float randomDuration = Random.Range(0.5f, 1f);

        while (elapsedTime < randomDuration && glManager.battleAI.boolActionsDict["TakeGuard"]) 
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StopTakeGuard();
    }

    public void StopTakeGuard(){
        glManager.animationsManager.StopAction("TakeGuard");
        glManager.battleAI.boolActionsDict["TakeGuard"] = false;

        //attributes.battleAI.setOldActionValueFalse();
    }

    public void WalkToPoint(Vector2 targetPosition, float speed){
        StartCoroutine(WalkToPointCoroutine(targetPosition,speed));
    }

    IEnumerator WalkToPointCoroutine(Vector2 targetPosition, float speed)
    {
        glManager.animationsManager.StartAnim("Walk");

        while (!hasArrivedToWalkDest(targetPosition))
        {
            // Calculate the direction and distance to the target
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            float distanceToTarget = Vector2.Distance(transform.position, targetPosition);

            // Calculate the movement amount based on the distance and walk speed
            float movementAmount = Mathf.Min(GetComponent<GLAttributes>().WalkSpeed * Time.deltaTime * speed, distanceToTarget);

            // Move towards the target using Transform.Translate
            transform.Translate(direction * movementAmount, Space.World);

            yield return null;
        }

        StopWalkToPoint();
    }

    public void StopWalkToPoint(){
        glManager.animationsManager.StopAnim("Walk");
    }


    public GameObject FindNearestEnemy()
    {
        // for player
        if (gameObject.tag.Equals("Player")){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                Debug.LogWarning("No enemies found in the scene.");
                return null;
            }

            GameObject nearestEnemy = null;
            float shortestDistance = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<GLState>().alive){
                    float distanceToEnemy = Vector3.Distance(enemy.transform.position, currentPosition);

                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                }
            }

            return nearestEnemy;
        }

        // for enemy
        else if (gameObject.tag.Equals("Enemy")){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");

            if (enemies.Length == 0)
            {
                Debug.LogWarning("No enemies found in the scene.");
                return null;
            }

            GameObject nearestEnemy = null;
            float shortestDistance = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<GLState>().alive){
                    float distanceToEnemy = Vector3.Distance(enemy.transform.position, currentPosition);

                    if (distanceToEnemy < shortestDistance)
                    {
                        shortestDistance = distanceToEnemy;
                        nearestEnemy = enemy;
                    }
                }
            }

            return nearestEnemy;
        }

        else{
            return null;
        }
    }

    public void DoBeforeFightAnim(){
        StartCoroutine(DoBeforeFightAnimCoroutine());
    }

    IEnumerator DoBeforeFightAnimCoroutine()
    {
        glManager.animationsManager.StartAnim("BeforeFight_1");

        // Wait until the animation ends
        yield return new WaitForSeconds(glManager.animator.GetCurrentAnimatorStateInfo(0).length);

        // Set the animation parameter to false
        glManager.animationsManager.StopAnim("BeforeFight_1");
    }

    public Vector2 ImproveTargetPos(Vector2 targetPosition)
    {
        GameObject borderUpperObject = GameObject.Find("BorderUpper");
        GameObject borderLowerObject = GameObject.Find("BorderLower");
        GameObject borderLeftObject = GameObject.Find("BorderLeft");
        GameObject borderRightObject = GameObject.Find("BorderRight");


        float borderUpperYPosition = borderUpperObject.transform.position.y;
        float borderLowerYPosition = borderLowerObject.transform.position.y;
        float borderLeftXPosition = borderLeftObject.transform.position.x;
        float borderRightXPosition = borderRightObject.transform.position.x;

        if (targetPosition.y >= borderUpperYPosition - 0.4f)
        {
            targetPosition.y = borderUpperYPosition - 1f;

            Debug.Log("targetposition fixed");
        }

        if (targetPosition.y <= borderLowerYPosition + 0.4f)
        {
            targetPosition.y = borderLowerYPosition + 1f;

            Debug.Log("targetposition fixed");
        }

        if (targetPosition.x <= borderLeftXPosition + 0.4f)
        {
            targetPosition.x = borderLeftXPosition + 1f;

            Debug.Log("targetposition fixed");
        }

        if (targetPosition.x >= borderRightXPosition - 0.4f)
        {
            targetPosition.x = borderRightXPosition - 1f;

            Debug.Log("targetposition fixed");
        }

        return targetPosition;

    }

    public void faceTowardsEnemy(Vector2 enemyPos){
        Vector2 direction = (enemyPos - (Vector2)transform.position).normalized;

        if (direction.x < 0) // Enemy is on the left
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z); // Face left
        }
        else // Enemy is on the right
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z); // Face right
        }
    }

    public void GetKilled(){
        glManager.battleAI.StopAI();

        int randomDeathAnim = Random.Range(1, 4);

        string animName = "Death_Backwards";

        if (randomDeathAnim == 0) animName = "Death_Kneeling";
        else if (randomDeathAnim == 1) animName = "Death_Backwards";

        StartCoroutine(getKilledCoroutine(animName));
    }

    private IEnumerator getKilledCoroutine(string animationName){
        // Stop all current animations
        glManager.animationsManager.StopAllAnim();

        // Start death animation
        glManager.animationsManager.StartAnim(animationName);

        // Wait for the animation to complete
        while (glManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Set final state
        glManager.state.alive = false;
        glManager.state.dying = false;
    }

}
