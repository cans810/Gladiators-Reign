using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BattleAI : MonoBehaviour
{
    Attributes attributes;
    public bool startAI;

    public Dictionary<string,bool> boolActionsDict;
    public List<string> actionsList;
    public string currentActionKey;
    public ActionQueue actionQueue;
    public ActionItem currentAction;



    public GameObject currentEnemyChosen;
    public Vector2 targetWalkPos;

    public void FillActionsDict(){
        boolActionsDict = new Dictionary<string, bool>();
        boolActionsDict.Add("isWalkingToMeleeAttack",false);
        boolActionsDict.Add("isKeepingDistance",false);

        // Initialize the actionsList
    actionsList = new List<string>();

    // Iterate over the keys of boolActionsDict and add them to actionsList
    foreach (string key in boolActionsDict.Keys)
    {
        actionsList.Add(key);
    }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        FillActionsDict();
        attributes = GetComponent<Attributes>();

        actionQueue = GetComponent<ActionQueue>();

        actionQueue.Enqueue("CommonActions","WalkToPointMeleeAttack",true,false);
        actionQueue.Enqueue("CommonActions","KeepDistance",true,false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (attributes.alive && actionQueue.getTop() == null && startAI){
            // actions plot
            int randomAction = UnityEngine.Random.Range(0,boolActionsDict.Count);

            actionQueue.Enqueue("CommonActions","WalkToPointMeleeAttack",true,false);
        }

        if (startAI && attributes.alive)
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
                else if (prioritizedAction == null && !attributes.inAction){
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
