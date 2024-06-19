using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GLAttributes : MonoBehaviour
{
    GladiatorManager glManager;
    public string gladiator_name;

    public string race;

    public float walk_speed;

    public int max_HP;

    public int HP;
    public int MP;
    public int SP;

    public int Strength; // Determines physical attack power and ability to wield heavy weapons.
    public int Dexterity; // Affects accuracy, evasion, and speed, also influences ranged attack power.
    public int Intelligence; // Determines magical power and effectiveness of spells. 
    public int Vitality; // Influences HP.
    public int Wisdom; // Affects MP and spell effectiveness, particularly for support and healing spells.
    public int Endurance; // Influences SP.  
    public int Charisma; // Affects interactions with NPCs, bargaining prices, and influence in dialogue options.
    public int Luck; // Affects the probability of critical hits, rare loot drops, and success in certain actions.

    //
    public int amount_GotHit;

    //
    public int coin;
    public float fame;
    public int level;
    
    //
    public Vector3 battleSize;

    public void Awake(){
        glManager = GetComponent<GladiatorManager>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        battleSize = new Vector3(0.7f,0);

        //GetComponent<AppereanceManager>().setRace();
        //GetComponent<AppereanceManager>().setRegion();

        HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            if (HP <= 0){
                glManager.state.dying = true;
            }
            else{
                glManager.state.dying = false;
            }
        }

        if (!glManager.animationsManager.isAnimating && !glManager.animationsManager.inAction && !SceneManager.GetActiveScene().name.Equals("BattleScene")){
            glManager.animator.SetBool("Idle",true);
        }
        else{
            glManager.animator.SetBool("Idle",false);
        }

        if (glManager.battleAI.currentActionKey != "GetKilled" && glManager.state.dying && glManager.state.alive){
            glManager.battleAI.actionQueue.ClearQueue();
            glManager.battleAI.actionQueue.Enqueue("GLCommonActions","GetKilled",false,true);
        }
    }
}
