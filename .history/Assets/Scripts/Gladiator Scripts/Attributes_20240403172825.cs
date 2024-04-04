using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    // managers
    public Rigidbody2D rb;
    public CommonActions commonActions;
    public BattleAI battleAI;
    public EntitySortingLayerController sortingLayerController;

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
        rb = GetComponent<Rigidbody2D>();
        commonActions = GetComponent<CommonActions>();
        battleAI = GetComponent<BattleAI>();
        sortingLayerController = GetComponent<EntitySortingLayerController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AppereanceManager>().setRace();
        GetComponent<AppereanceManager>().setRegion();

        alive = true;
        HP = MAX
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
