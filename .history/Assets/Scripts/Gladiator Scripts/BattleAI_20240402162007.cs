using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAI : MonoBehaviour
{
    Attributes attributes;
    public bool startAI;

    // Start is called before the first frame update
    void Start()
    {
        attributes = G
    }

    // Update is called once per frame
    void Update()
    {
        if (startAI){
            // ai loop
        }
    }

    public void StartAI(){
        startAI = true;
    }

}
