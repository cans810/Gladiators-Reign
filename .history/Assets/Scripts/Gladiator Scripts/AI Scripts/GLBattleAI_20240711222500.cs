using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GLBattleAI : MonoBehaviour
{
    GladiatorManager gladiatorManager;
    public bool startAI;

    public Dictionary<string,bool> boolActionsDict;
    public List<string> actionsList;
    public string currentActionKey;
    public GLActionQueue actionQueue;
    public ActionItem currentAction;

    public GameObject currentEnemyChosen;
    public Vector2 targetWalkPos;

    public void FillActionsDict(){
        boolActionsDict = new Dictionary<string, bool>();
        boolActionsDict.Add("WalkToPointMeleeAttack",false);
        boolActionsDict.Add("KeepDistance",false);
        boolActionsDict.Add("TakeGuard",false);
        boolActionsDict.Add("GetKilled",false);

        actionsList = new List<string>();
        foreach (string key in boolActionsDict.Keys)
        {
            actionsList.Add(key);
        }
    }
    
    void Start()
    {
        FillActionsDict();
        gladiatorManager = GetComponent<GladiatorManager>();
        actionQueue = GetComponent<GLActionQueue>();
    }

    void Update()
    {
        if (GetComponent<GLState>().alive && startAI && !GetComponent<GLState>().dying)
        {
            while (actionQueue.queue.Count < 3) 
            {
                int randomAction = UnityEngine.Random.Range(0, boolActionsDict.Count);
                if (actionsList[randomAction] != "GetKilled" )
                {
                    if (gameObject.GetComponent<BloodreaverActions>() != null){
                        gameObject.GetComponent<BloodreaverActions>().BloodreaverAI();
                    }

                }
            }
        }

        if(startAI){
            ExecuteNext();

            foreach (KeyValuePair<string, bool> kvp in boolActionsDict)
            {
                if (kvp.Value)
                {
                    currentActionKey = kvp.Key;
                    break;
                }
            }
        }
    }

    public void StartAI(){
        startAI = true;
    }
    
    public void StopAI(){
        startAI = false;
        actionQueue.ClearQueue();
        currentAction = null;
        currentActionKey = string.Empty;
        List<string> keys = new List<string>(boolActionsDict.Keys);
        foreach (string key in keys)
        {
            boolActionsDict[key] = false;
        }
    }

    public void ExecuteNext()
    {
        if (actionQueue.queue.Count > 0)
        {
            currentAction = actionQueue.getTop();

            if (currentAction != null)
            {
                ActionItem prioritizedAction = null;
                foreach (ActionItem actionItem in actionQueue.queue)
                {
                    if (actionItem != currentAction){
                        if (actionItem.hasPriority && currentAction.interruptable)
                        {
                            prioritizedAction = actionItem;
                            break;
                        }
                    }
                    else if (actionItem == currentAction){
                        if (actionQueue.queue.Count == 1){
                            prioritizedAction = actionItem;
                            break;
                        }
                    }
                }

                if (prioritizedAction != null)
                {
                    setOldActionValueFalse();
                    actionQueue.queue.Remove(prioritizedAction);
                    actionQueue.queue.Insert(0, prioritizedAction);
                    currentAction = actionQueue.Dequeue();
                    executeAction();
                }
                else if (prioritizedAction == null && !gladiatorManager.animationsManager.inAction){
                    currentAction = actionQueue.Dequeue();
                    executeAction();
                }
            }
        }
    }

    public void executeAction(){
        MonoBehaviour component = gameObject.GetComponent(currentAction.className) as MonoBehaviour;

        if (component != null)
        {
            MethodInfo method = component.GetType().GetMethod(currentAction.methodName);
            
            if (method != null)
            {
                object[] parameters = currentAction.parameters ?? new object[0];
                method.Invoke(component, parameters);
            }
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