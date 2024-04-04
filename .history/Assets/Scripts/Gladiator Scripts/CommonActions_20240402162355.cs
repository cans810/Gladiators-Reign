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

    public void WalkToPoint(Vector2 position){
        isExecutingAction = true;
        StartCoroutine(WalkToPointCoroutine(position));
    }

    IEnumerator WalkToPointCoroutine(Vector2 position){
        targetWalkPos = position;
        boolActionsDict["isWalking"] = true;

        Vector2 direction = (position - (Vector2)transform.position).normalized;

        rb.velocity = direction * attributes.walk_speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);

        while (!hasArrivedToWalkDest(targetWalkPos))
        {
            yield return null; // Wait for the next frame
        }

        StopWalking();
    }

}
