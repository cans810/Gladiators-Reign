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

        while (!hasArrivedToWalkDest(targetWalkPos))
        {
            yield return null; // Wait for the next frame
        }

        StopWalking();
    }

}
