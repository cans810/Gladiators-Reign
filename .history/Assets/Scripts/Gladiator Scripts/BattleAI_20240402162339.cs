using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAI : MonoBehaviour
{
    Attributes attributes;
    public bool startAI;

    public Dictionary<string,bool> boolActionsDict;
    public string currentActionKey;

    public void FillActionsDict(){
        boolActionsDict = new Dictionary<string, bool>();
        boolActionsDict.Add("isWalkingToDest",false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        FillActionsDict();
        attributes = GetComponent<Attributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startAI && attributes.alive){
            // find the nearest attackable enemy
            // go near it
            // execute attack
        }
    }

    public void StartAI(){
        startAI = true;
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
