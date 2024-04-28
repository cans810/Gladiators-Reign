using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonActions : MonoBehaviour
{
    Attributes attributes;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        if (attributes.alive){
            if (attributes.battleAI.currentEnemyChosen != null){
                faceTowardsEnemy(attributes.battleAI.currentEnemyChosen.transform.position);
            }
        }
    }

    public void AttackMelee(){
        if (attributes.battleAI.currentEnemyChosen != null){
            GetComponent<AnimationsManager>().StartAnim("AttackMelee_1",true);
        }
    }

    public void WalkToPointMeleeAttack(){
        attributes.battleAI.currentEnemyChosen = FindNearestEnemy();

        StartCoroutine(WalkToPointMeleeAttackCoroutine());
    }

    IEnumerator WalkToPointMeleeAttackCoroutine()
    {
        GetComponent<AnimationsManager>().StartAnim("Walk", true);

        attributes.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = true;

        attributes.battleAI.targetWalkPos = ImproveTargetPos(attributes.battleAI.currentEnemyChosen.transform.position);

        Vector2 direction = (attributes.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToAttack(attributes.battleAI.targetWalkPos))
        {
            attributes.battleAI.targetWalkPos = ImproveTargetPos(attributes.battleAI.currentEnemyChosen.transform.position);

            direction = (attributes.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

            yield return null; // Wait for the next frame
        }

        GetComponent<AnimationsManager>().StopAnim("Walk", true);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        AttackMelee();
    }


    public void DamageMelee(){
        if (attributes.HitBox.objectsInHitbox.Contains(attributes.battleAI.currentEnemyChosen)){
            if (attributes.battleAI.currentEnemyChosen != null && !attributes.battleAI.currentEnemyChosen.GetComponent<BattleAI>().boolActionsDict["TakeGuard"] ){
                int hpBefore = (int)attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().HP;
                attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().HP -= 1;
                attributes.battleAI.currentEnemyChosen.GetComponent <Attributes>().amount_GotHit = hpBefore - attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().HP;

                attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().PopupsManager.GetComponent<PopUpsManager>().HitPopUp(attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().amount_GotHit
                ,attributes.battleAI.currentEnemyChosen);
                
                StartCoroutine(OpponentGotHitCoroutine(attributes.battleAI.currentEnemyChosen));
            }
            else if(attributes.battleAI.currentEnemyChosen != null && attributes.battleAI.currentEnemyChosen.GetComponent<BattleAI>().boolActionsDict["TakeGuard"]){
                Debug.Log("enemy is blocking.");
            }
        }
        else{
            Debug.Log("attack missed.");
        }
    }

    IEnumerator OpponentGotHitCoroutine(GameObject opponent){

        opponent.GetComponent<Attributes>().gotHit = true;

        yield return new WaitForSeconds(3f);

        opponent.GetComponent<Attributes>().gotHit = false;
    }

    public void StopAttackMelee(){
        attributes.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = false;
        GetComponent<AnimationsManager>().StopAnim("AttackMelee_1",true);

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
        attributes.battleAI.currentEnemyChosen = FindNearestEnemy();

        StartCoroutine(KeepDistanceCoroutine());
    }

    IEnumerator KeepDistanceCoroutine()
    {
        GetComponent<AnimationsManager>().StartAnim("Walk", true);
        attributes.battleAI.boolActionsDict["KeepDistance"] = true;

        Vector2 enemyPosition = attributes.battleAI.currentEnemyChosen.transform.position;

        float randomDistance = UnityEngine.Random.Range(1f, 2f);

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 targetPosition = enemyPosition + randomDirection * randomDistance;

        targetPosition = ImproveTargetPos(targetPosition);

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToWalkDest(targetPosition))
        {
            direction = (targetPosition - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

            yield return null; // Wait for the next frame
        }

        // Stop keeping distance
        StopKeepDistance();
    }

    public void StopKeepDistance(){
        GetComponent<AnimationsManager>().StopAnim("Walk",true);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attributes.battleAI.boolActionsDict["KeepDistance"] = false;

        //attributes.battleAI.currentEnemyChosen = null;
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
        GetComponent<AnimationsManager>().StartAnim("TakeGuard",true);
        attributes.battleAI.boolActionsDict["TakeGuard"] = true;

        // generate a random duration between 0.5 to 1.5 seconds
        float randomDuration = Random.Range(0.5f, 1f);

        yield return new WaitForSeconds(randomDuration);

        StopTakeGuard();
    }

    public void StopTakeGuard(){
        GetComponent<AnimationsManager>().StopAnim("TakeGuard",true);
        attributes.battleAI.boolActionsDict["TakeGuard"] = false;
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
                if (enemy.GetComponent<Attributes>().alive){
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
                if (enemy.GetComponent<Attributes>().alive){
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
        GetComponent<AnimationsManager>().StartAnim("BeforeFight_1",false);

        // Wait until the animation ends
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Set the animation parameter to false
        GetComponent<AnimationsManager>().StopAnim("BeforeFight_1",false);
    }

    public Vector2 ImproveTargetPos(Vector2 targetPosition)
    {
        GameObject borderUpperObject = GameObject.Find("BorderUpper");
        GameObject borderLowerObject = GameObject.Find("BorderLower");

        if (borderUpperObject != null)
        {
            float borderYPosition = borderUpperObject.transform.position.y;

            if (targetPosition.y >= borderYPosition - 0.4f)
            {
                targetPosition.y = borderYPosition - 1f; // Use a constant or configurable parameter

                Debug.Log("targetposition fixed");
            }

            return targetPosition;
        }
        else
        {
            Debug.LogWarning("GameObject 'Border1' not found.");
            return targetPosition; // Return the original target position if the border is not found
        }
    }

    public void faceTowardsEnemy(Vector2 enemyPos){
        Vector2 direction = (enemyPos - (Vector2)transform.position).normalized;

        if (direction.x < 0) // Enemy is on the left
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.z); // Face left
        }
        else // Enemy is on the right
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z); // Face left
        }
    }

    public void GetKilled(){
        StartCoroutine(getKilledCoroutine("Death_1"));
    }

    private IEnumerator getKilledCoroutine(string animationName){
        attributes.battleAI.boolActionsDict["Dying"] = true;

        GetComponent<AnimationsManager>().StartAnim("Death_1", true);

        if (attributes.animator == null)
        {
            Debug.LogError("Animator component not found!");
            yield break;
        }

        int animationHash = Animator.StringToHash(animationName);

        while (attributes.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f &&
            attributes.animator.GetCurrentAnimatorStateInfo(0).fullPathHash == animationHash)
        {
            yield return null;
        }


        Debug.Log("clean dead body...");
    }

}
