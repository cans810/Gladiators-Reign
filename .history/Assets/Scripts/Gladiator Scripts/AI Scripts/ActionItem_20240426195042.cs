using System;

[Serializable] 
public class ActionItem
    {
        public string className;
        public string methodName;
        public object[] parameters;
        public bool interruptable;
        public bool hasPriority;

        public ActionItem(string className, string methodName, object[] parameters, bool interruptable, bool hasPriority)
        {
            this.className = className;
            this.methodName = methodName;
            this.parameters = parameters;
            this.interruptable = interruptable;
            this.hasPriority = hasPriority;
        }
    }