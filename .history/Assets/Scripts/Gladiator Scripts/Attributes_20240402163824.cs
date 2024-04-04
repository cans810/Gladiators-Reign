using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    // managers
    public CommonActions commonActions;
    public BattleAI battleAI;

    public string race;
    public string raceRegion;

    public string gladiator_name;
    public int level;

    public float walk_speed;

    public float max_HP;
    public float HP;


    //
    public bool inAction;
    public bool alive;

    public void Awake(){
        commonActions = GetComponent<CommonActions>();
        battleAI = GetComponent<BattleAI>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AppereanceManager>().setRace();
        GetComponent<AppereanceManager>().setRegion();

        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
