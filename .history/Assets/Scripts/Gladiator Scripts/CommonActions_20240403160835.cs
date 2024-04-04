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

    public void AttackMelee(){
        if (attributes.battleAI.currentEnemyChosen != null && attributes.battleAI.currentEnemyChosen.GetComponent<Attributes>().alive){
            animator.SetBool("AttackMelee_1",true);
        }
    }

    public void WalkToPointMeleeAttack(){
        attributes.inAction = true;

        attributes.battleAI.currentEnemyChosen = FindNearestEnemy();

        StartCoroutine(WalkToPointMeleeAttackCoroutine());
    }

    IEnumerator WalkToPointMeleeAttackCoroutine()
    {
        animator.SetBool("Walk", true);

        attributes.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = true;

        attributes.battleAI.targetWalkPos = ImproveTargetPos(attributes.battleAI.currentEnemyChosen.transform.position);

        attributes.battleAI.targetWalkPos = ImproveTargetPos(attributes.battleAI.currentEnemyChosen.transform.position);

        Vector2 direction = (attributes.battleAI.targetWalkPos - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToAttack(attributes.battleAI.targetWalkPos))
        {
            yield return null; // Wait for the next frame
        }

        animator.SetBool("Walk",false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        AttackMelee();
    }

    public void StopAttackMelee(){
        attributes.battleAI.boolActionsDict["WalkToPointMeleeAttack"] = false;
        animator.SetBool("AttackMelee_1", false);
        attributes.inAction = false;

        attributes.battleAI.currentEnemyChosen = null;
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
        attributes.inAction = true;

        attributes.battleAI.currentEnemyChosen = FindNearestEnemy();

        StartCoroutine(KeepDistanceCoroutine());
    }

    IEnumerator KeepDistanceCoroutine()
    {
        animator.SetBool("Walk", true);
        attributes.battleAI.boolActionsDict["KeepDistance"] = true;

        Vector2 enemyPosition = attributes.battleAI.currentEnemyChosen.transform.position;

        float randomDistance = UnityEngine.Random.Range(1f, 2f);

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 targetPosition = enemyPosition + randomDirection * randomDistance;

        attributes.battleAI.targetWalkPos = ImproveTargetPos(targetPosition);

        // Calculate the direction to the target position
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        // Apply the velocity to the Rigidbody2D component
        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToWalkDest(attributes.battleAI.targetWalkPos))
        {
            faceTowardsEnemy
            yield return null; // Wait for the next frame
        }

        // Stop keeping distance
        StopKeepDistance();
    }

    public void StopKeepDistance(){
        animator.SetBool("Walk",false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attributes.battleAI.boolActionsDict["KeepDistance"] = false;
        attributes.inAction = false;

        attributes.battleAI.currentEnemyChosen = null;
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
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, currentPosition);

                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
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
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, currentPosition);

                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }

        else{
            return null;
        }
    }

    public Vector2 ImproveTargetPos(Vector2 targetPosition){

        // Find the GameObject called "Border1"
        GameObject borderObject = GameObject.Find("Border1");

        if (borderObject != null)
        {
            // Get the Y position of the edge collider of the "Border1" GameObject
            float borderYPosition = borderObject.transform.position.y; // Get the maximum Y position of the collider bounds

            // If the target position is higher than the border's Y position, adjust it
            if (targetPosition.y - 1 >= borderYPosition)
            {
                // Set the target position to be just below the border's Y position
                targetPosition.y = borderYPosition - 1f; // Adjust as necessary
            }

            return targetPosition;
        }
        else
        {
            Debug.LogWarning("GameObject 'Border1' not found.");
            return Vector2.zero;
        }
    }

    public void faceTowardsEnemy(Vector2 enemyPos){
        Vector2 direction = (enemyPos - (Vector2)transform.position).normalized;

        if (direction.x < 0) // Enemy is on the left
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Face left
        }
        else // Enemy is on the right
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Face right
        }
    }

}
