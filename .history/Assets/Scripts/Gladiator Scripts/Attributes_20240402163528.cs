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

    public float walk_distance;
    public float walk_speed;

    public float max_HP;
    public float HP;


    //
    public bool inAction;
    public bool alive;
    
    // Start is called before the first frame update
    void Start()
    {
        commonActions = GetComponent<CommonActions>();
        battleAI = GetComponent<BattleAI>

        GetComponent<AppereanceManager>().setRace();
        GetComponent<AppereanceManager>().setRegion();

        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
