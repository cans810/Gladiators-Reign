using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAI : MonoBehaviour
{
    Attributes attributes;
    public bool startAI;

    public Dictionary<string,bool> boolActionsDict;
    public string currentActionKey;
    public ActionQueue actionQueue;
    public bool isExecutingAction;
    public ActionItem currentAction;



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
            attributes.commonActions.WalkToPointMeleeAttack(attributes.commonActions.FindNearestEnemy().transform.position);

        }

        if (attributes.alive)
        {
            ExecuteNext();

            foreach (KeyValuePair<string, bool> kvp in boolActionsDict)
            {
                if (kvp.Value){
                    currentActionKey = kvp.Key;
                    break;
                }
                else{
                    currentActionKey = "none";
                }
            }
        }
    }

    public void StartAI(){
        startAI = true;
    }

    public void ExecuteNext()
    {
        // execute the actions in the queue of this game object
        if (actionQueue.queue.Count > 0)
        {
            currentAction = actionQueue.getTop();

            if (currentAction != null)
            {
                // check if any action item in the queue has priority and the current action is interruptable
                ActionItem prioritizedAction = null;
                foreach (ActionItem actionItem in actionQueue.queue)
                {
                    if (actionItem.hasPriority && currentAction.interruptable)
                    {
                        prioritizedAction = actionItem;
                        break;
                    }
                }

                // if a prioritized action item is found, move it to the front of the queue
                if (prioritizedAction != null)
                {
                    setOldActionValueFalse();

                    actionQueue.queue.Remove(prioritizedAction);
                    actionQueue.queue.Insert(0, prioritizedAction);

                    currentAction = actionQueue.Dequeue();
                    executeAction();
                    
                }
                else if (prioritizedAction == null && !isExecutingAction){
                    currentAction = actionQueue.Dequeue();
                    executeAction();
                }
            }
        }
    }

    public void executeAction(){
        // get the component attached to the current GameObject
        MonoBehaviour component = gameObject.GetComponent(currentAction.className) as MonoBehaviour;

        if (component != null)
        {
            // get the method from the component's type
            MethodInfo method = component.GetType().GetMethod(currentAction.methodName);
            
            if (method != null)
            {
                // invoke the method on the component
                object[] parameters = currentAction.parameters ?? new object[0];
                method.Invoke(component, parameters);
                Debug.LogWarning("Method found: " + currentAction.methodName + " in class: " + currentAction.className + " for " + gameObject.name);
            }
            else
            {
                Debug.LogWarning("Method not found: " + currentAction.methodName + " in class: " + currentAction.className);
            }
        }
        else
        {
            Debug.LogWarning("Component not found: " + currentAction.className + " on GameObject: " + gameObject.name);
        }
    }

    public void setOldActionValueFalse(){
        foreach (KeyValuePair<string, bool> kvp in boolActionsDict)
        {
            if (kvp.Key == currentActionKey)
            {
                boolActionsDict[kvp.Key] = false;
                break;
            }
        }
    }

}
