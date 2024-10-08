using UnityEngine;
using System.Collections.Generic;
using System;

public class GL : MonoBehaviour
{
    [SerializeField] public List<ActionItem> queue;

    
    void Awake(){
        queue = new List<ActionItem>();
    }

    public void Enqueue(string className, string methodName, bool interruptable, bool hasPriority ,params object[] parameters)
    {
        queue.Add(new ActionItem(className, methodName, interruptable, hasPriority, parameters));
    }

    public ActionItem Dequeue()
    {
        if (queue.Count > 0)
        {
            ActionItem item = queue[0];
            queue.RemoveAt(0);
            return item;
        }
        else
        {
            return null;
        }
    }

    public ActionItem getTop(){
        if (queue.Count > 0)
        {
            ActionItem item = queue[0];
            return item;
        }
        else
        {
            return null;
        }
    }

    public void ClearQueue(){
        queue.Clear();
    }
}
