using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonActions : MonoBehaviour
{
    Attributes attributes;
    Animator animator;
    BattleAI battleAI;

    // Start is called before the first frame update
    void Start()
    {
        attributes = GetComponent<Attributes>();
        animator = GetComponent<Animator>();
        battleAI = GetComponent<BattleAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void WalkToPoint(Vector2 position){
        attributes.inAction = true;
        StartCoroutine(WalkToPointCoroutine(position));
    }

    IEnumerator WalkToPointCoroutine(Vector2 position){
        battleAI.targetWalkPos = position;
        battleAI.boolActionsDict["isWalkingToDest"] = true;

        Vector2 direction = (position - (Vector2)transform.position).normalized;

        GetComponent<Rigidbody2D>().velocity = direction * attributes.walk_speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().MoveRotation(angle);

        while (!hasArrivedToWalkDest(battleAI.targetWalkPos))
        {
            yield return null; // Wait for the next frame
        }

        StopWalking();
    }

    public void StopWalking(){
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        battleAI.boolActionsDict["isWalkingToDest"] = false;
        attributes.inAction = false;
    }

    public bool hasArrivedToWalkDest(Vector2 targetPos){
        float distanceToTarget = Vector2.Distance(transform.position, targetPos);

        if (distanceToTarget <= 0.01f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            battleAI.boolActionsDict["isWalkingToDest"] = false;
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

        
    }

}
