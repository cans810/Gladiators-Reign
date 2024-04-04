using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAI : MonoBehaviour
{
    Attributes attributes;
    public bool startAI;

    public Dictionary<string,bool> boolActionsDict;
    public string currentActionKey;

    public GameObject currentEnemyChosen;
    public Vector2 targetWalkPos;

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
            //// MELEE ATTACK LOOP
            // find the nearest attackable enemy
            // go near it
            // execute melee attack
            attributes.commonActions.WalkToPoint(attributes.commonActions.FindNearestEnemy().transform.position);

        }
    }

    public void StartAI(){
        startAI = true;
    }

    public void 

}
