using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attributes : MonoBehaviour
{
    // managers
    public Rigidbody2D rb;
    public CommonActions commonActions;
    public BattleAI battleAI;
    public EntitySortingLayerController sortingLayerController;
    public Animator animator;

    public string race;
    public string raceRegion;

    public string gladiator_name;

    public float walk_speed;

    public float max_HP;
    public float HP;


    //
    public bool inAction;
    public bool isAnimating;
    public bool alive;

    //
    public int coin;
    public float fame;
    public int level;
    

    public void Awake(){
        rb = GetComponent<Rigidbody2D>();
        commonActions = GetComponent<CommonActions>();
        battleAI = GetComponent<BattleAI>();
        sortingLayerController = GetComponent<EntitySortingLayerController>();
        animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AppereanceManager>().setRace();
        //GetComponent<AppereanceManager>().setRegion();

        alive = true;
        HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            if (HP <= 0){
                alive = false;
            }
            else{
                alive = true;
            }
        }

        if (!isAnimating && !inAction){
            animator.SetBool("Idle",true);
        }
    }
}
