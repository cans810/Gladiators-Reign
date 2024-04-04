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

        public void WalkToPointMeleeAttack(Vector2 position){
        attributes.inAction = true;
        StartCoroutine(WalkToPointCoroutine(position));
    }

    IEnumerator WalkToPointMeleeAttackCoroutine(Vector2 position){
        animator.SetBool("Walk",true);

        attributes.battleAI.targetWalkPos = position;
        attributes.battleAI.boolActionsDict["isWalkingToDest"] = true;

        Vector2 direction = (position - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToWalkDest(attributes.battleAI.targetWalkPos))
        {
            yield return null; // Wait for the next frame
        }

        StopWalkingMeleeAttack();
        AttackMelee();
    }

    public void StopWalkingMeleeAttack(){
        animator.SetBool("Walk",true);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attributes.battleAI.boolActionsDict["isWalkingToDest"] = false;
        attributes.inAction = false;
    }

    public void WalkToPoint(Vector2 position){
        attributes.inAction = true;
        StartCoroutine(WalkToPointCoroutine(position));
    }

    IEnumerator WalkToPointCoroutine(Vector2 position){
        animator.SetBool("Walk",true);

        attributes.battleAI.targetWalkPos = position;
        attributes.battleAI.boolActionsDict["isWalkingToDest"] = true;

        Vector2 direction = (position - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        while (!hasArrivedToWalkDest(attributes.battleAI.targetWalkPos))
        {
            yield return null; // Wait for the next frame
        }

        StopWalking();
    }

    public void StopWalking(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        attributes.battleAI.boolActionsDict["isWalkingToDest"] = false;
        attributes.inAction = false;
    }

    public bool hasArrivedToWalkDest(Vector2 targetPos){
        float distanceToTarget = Vector2.Distance(transform.position, targetPos);

        if (distanceToTarget <= 1.3f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            attributes.battleAI.boolActionsDict["isWalkingToDest"] = false;
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
