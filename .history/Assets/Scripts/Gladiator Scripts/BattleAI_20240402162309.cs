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
        boolActionsDict.Add("isWalking",false);
        boolActionsDict.Add("isWandering",false);
        boolActionsDict.Add("isBreeding",false);
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

}
