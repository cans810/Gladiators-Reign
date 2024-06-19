using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonActions : MonoBehaviour
{
    GladiatorManager gladiatorManager;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        gladiatorManager = GetComponent<GladiatorManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void FixedUpdate()
    {
        if (gladiatorManager.alive){
            if (gladiatorManager.battleAI.currentEnemyChosen != null){
                faceTowardsEnemy(gladiatorManager.battleAI.currentEnemyChosen.transform.position);
            }
        }
    }

    public void AttackMelee(){
        if (gladiatorManager.battleAI.currentEnemyChosen != null && gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().alive){
            GetComponent<AnimationsManager>().StartAction("AttackMelee_1");
        }
        else{
            StopAttackMelee();
        }
    }

    public void WalkToPointMeleeAttack(){
        gladiatorManager.battleAI.currentEnemyChosen = FindNearestEnemy();

        StartCoroutine(WalkToPointMeleeAttackCoroutine());
    }

    IEnumerator WalkToPointMeleeAttackCoroutine()
    {
        GetComponent<AnimationsManager>().StartAction("Walk");
        gladiatorManager.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = true;

        gladiatorManager.battleAI.targetWalkPos = ImproveTargetPos(gladiatorManager.battleAI.currentEnemyChosen.transform.position);

        Vector2 direction = (gladiatorManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * gladiatorManager.walk_speed;

        while (!hasArrivedToAttack(gladiatorManager.battleAI.targetWalkPos) && gladiatorManager.battleAI.boolActionsDict["WalkToPointMeleeAttack"] == true 
        && gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().alive)
        {
            gladiatorManager.battleAI.targetWalkPos = ImproveTargetPos(gladiatorManager.battleAI.currentEnemyChosen.transform.position);

            direction = (gladiatorManager.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * gladiatorManager.walk_speed;

            yield return null; // Wait for the next frame
        }

        GetComponent<AnimationsManager>().StopAction("Walk");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (gladiatorManager.battleAI.boolActionsDict["WalkToPointMeleeAttack"] == true 
        && (!gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().dying && gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().alive)){
            AttackMelee();
        }
        else{
            StopAttackMelee();
        }
    }


    public void DamageMelee(){
        if (gladiatorManager.HitBox.objectsInHitbox.Contains(gladiatorManager.battleAI.currentEnemyChosen)){
            if (gladiatorManager.battleAI.currentEnemyChosen != null && !gladiatorManager.battleAI.currentEnemyChosen.GetComponent<BattleAI>().boolActionsDict["TakeGuard"] 
            && (!gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().dying && gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().alive)){
                int hpBefore = (int)gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().HP;
                gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().HP -= 1;
                gladiatorManager.battleAI.currentEnemyChosen.GetComponent <Attributes>().amount_GotHit = hpBefore - gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().HP;

                gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().PopupsManager.GetComponent<PopUpsManager>().HitPopUp(gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().amount_GotHit
                ,gladiatorManager.battleAI.currentEnemyChosen);
                
                StartCoroutine(OpponentGotHitCoroutine(gladiatorManager.battleAI.currentEnemyChosen));
            }
            else if(attributes.battleAI.currentEnemyChosen != null && gladiatorManager.battleAI.currentEnemyChosen.GetComponent<BattleAI>().boolActionsDict["TakeGuard"]){
                Debug.Log("enemy is blocking.");
            }
            else if (attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().dying || !gladiatorManager.battleAI.currentEnemyChosen.GetComponent<Attributes>().alive){
                //Debug.Log("enemy dead or dying");
                StopAttackMelee();
            }
        }
        else{
            Debug.Log("attack missed.");
        }
    }

    IEnumerator OpponentGotHitCoroutine(GameObject opponent){

        opponent.GetComponent<Attributes>().gotHit = true;
        
        if (!opponent.GetComponent<Attributes>().dying || opponent.GetComponent<Attributes>().alive){
            yield return new WaitForSeconds(3f);
        }
        else{
            StopCoroutine(OpponentGotHitCoroutine(opponent));
        }

        opponent.GetComponent<Attributes>().gotHit = false;
    }

    public void StopAttackMelee(){
        GetComponent<AnimationsManager>().StopAction("AttackMelee_1");
        attributes.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = false;

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
        GetComponent<AnimationsManager>().StartAction("Walk");
        attributes.battleAI.boolActionsDict["KeepDistance"] = true;

        Vector2 enemyPosition = attributes.battleAI.currentEnemyChosen.transform.position;

        float randomDistance = UnityEngine.Random.Range(1f, 2f);

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 targetPosition = enemyPosition + randomDirection * randomDistance;

        targetPosition = ImproveTargetPos(targetPosition);

        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToWalkDest(targetPosition) && attributes.battleAI.boolActionsDict["KeepDistance"] == true
        && attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().alive)
        {
            direction = (targetPosition - (Vector2)transform.position).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

            yield return null; // Wait for the next frame
        }

        // Stop keeping distance
        StopKeepDistance();
    }

    public void StopKeepDistance(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<AnimationsManager>().StopAction("Walk");
        attributes.battleAI.boolActionsDict["KeepDistance"] = false;
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
        GetComponent<AnimationsManager>().StartAction("TakeGuard");
        attributes.battleAI.boolActionsDict["TakeGuard"] = true;

        float elapsedTime = 0f;
        float randomDuration = Random.Range(0.5f, 1f);

        while (elapsedTime < randomDuration && attributes.battleAI.boolActionsDict["TakeGuard"]) 
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        StopTakeGuard();
    }

    public void StopTakeGuard(){
        GetComponent<AnimationsManager>().StopAction("TakeGuard");
        attributes.battleAI.boolActionsDict["TakeGuard"] = false;

        //attributes.battleAI.setOldActionValueFalse();
    }

    public void WalkToPoint(Vector2 targetPosition, float speed){
        StartCoroutine(WalkToPointCoroutine(targetPosition,speed));
    }

    IEnumerator WalkToPointCoroutine(Vector2 targetPosition, float speed)
    {
        GetComponent<AnimationsManager>().StartAnim("Walk");

        while (!hasArrivedToWalkDest(targetPosition))
        {
            // Calculate the direction and distance to the target
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            float distanceToTarget = Vector2.Distance(transform.position, targetPosition);

            // Calculate the movement amount based on the distance and walk speed
            float movementAmount = Mathf.Min(attributes.walk_speed * Time.deltaTime * speed, distanceToTarget);

            // Move towards the target using Transform.Translate
            transform.Translate(direction * movementAmount, Space.World);

            yield return null;
        }

        StopWalkToPoint();
    }

    public void StopWalkToPoint(){
        GetComponent<AnimationsManager>().StopAnim("Walk");
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
        GetComponent<AnimationsManager>().StartAnim("BeforeFight_1");

        // Wait until the animation ends
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Set the animation parameter to false
        GetComponent<AnimationsManager>().StopAnim("BeforeFight_1");
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
        StartCoroutine(getKilledCoroutine("Death_1"));
    }

    private IEnumerator getKilledCoroutine(string animationName){

        // get the Animator component
        Animator animator = attributes.animator;

        // get the AnimatorStateInfo for the base layer
        AnimatorStateInfo currentAnimState = animator.GetCurrentAnimatorStateInfo(0);

        // check if any animation is currently playing
        if (currentAnimState.normalizedTime < 1.0f)
        {
            // get the current animation clip information
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

            // get the clip name (assuming there's only one clip playing)
            string currentAnimName = clipInfo[0].clip.name;

            // set the boolean parameter with the current animation name
            GetComponent<AnimationsManager>().StopAnim(currentAnimName);
        }

        int randomDeathAnim = Random.Range(1,3);

        GetComponent<AnimationsManager>().StartAnim("Death_" + randomDeathAnim);

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

        //Debug.Log("clean dead body...");
        attributes.alive = false;
    }

}
