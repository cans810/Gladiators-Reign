using System;

[Serializable] 
public class ActionItem
    {
        public string className;
        public string methodName;
        public bool interruptable;
        public bool hasPriority;
        public object[] parameters;

        public ActionItem(string className, string methodName, bool interruptable, bool hasPriority, object[] parameters)
        {
            this.className = className;
            this.methodName = methodName;
            this.interruptable = interruptable;
            this.hasPriority = hasPriority;
            this.parameters = parameters;
        }
    }