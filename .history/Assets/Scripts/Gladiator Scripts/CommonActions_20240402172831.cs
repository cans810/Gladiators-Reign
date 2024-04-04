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
        StartCoroutine(WalkToPointMeleeAttackCoroutine(FindNearestEnemy().transform.position));
    }

    IEnumerator WalkToPointMeleeAttackCoroutine(Vector2 position)
    {
        animator.SetBool("Walk", true);

        attributes.battleAI.targetWalkPos = position;
        attributes.battleAI.boolActionsDict["isWalkingToMeleeAttack"] = true;

        Vector2 direction = (position - (Vector2)transform.position).normalized;

        if (direction.x < 0) // Enemy is on the left
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Face left
        }
        else // Enemy is on the right
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Face right
        }

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToWalkDest(attributes.battleAI.targetWalkPos))
        {
            yield return null; // Wait for the next frame
        }

        StopWalkingMeleeAttack();
        AttackMelee();
    }


    public void StopWalkingMeleeAttack(){
        animator.SetBool("Walk",false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attributes.battleAI.boolActionsDict["isWalkingToMeleeAttack"] = false;
        attributes.inAction = false;
    }

    public bool hasArrivedToWalkDest(Vector2 targetPos){
        float distanceToTarget = Vector2.Distance(transform.position, targetPos);

        if (distanceToTarget <= 1.3f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            attributes.battleAI.boolActionsDict["isWalkingToMeleeAttack"] = false;
            return true;
        }
        else{
            return false;
        }
    }

    public void KeepDistance(){
        attributes.inAction = true;
        StartCoroutine(WalkToPointMeleeAttackCoroutine(FindNearestEnemy().transform.position));
    }

    IEnumerator KeepDistanceCoroutine(Vector2 targetPos)
    {
        animator.SetBool("Walk", true);

        Vector2 direction = (transform.position - targetPos.position).normalized;

        Vector2 targetPosition = (Vector2)transform.position + direction * distance;

        while (Vector2.Distance(transform.position, targetPosition) > 0.01f)
        {
            // Move the character towards the target position
            GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(transform.position, targetPosition, attributes.walk_speed * Time.deltaTime));

            // Update rotation to face the enemy
            Vector2 lookDirection = (targetPos.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            yield return null; // Wait for the next frame
        }

        StopKeepDistance();
    }



    public void StopKeepDistance(){
        animator.SetBool("Walk",false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attributes.battleAI.boolActionsDict["isKeepingDistance"] = false;
        attributes.inAction = false;
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

            attributes.battleAI.currentEnemyChosen = nearestEnemy;

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

            attributes.battleAI.currentEnemyChosen = nearestEnemy;

            return nearestEnemy;
        }

        else{
            return null;
        }
    }

}
