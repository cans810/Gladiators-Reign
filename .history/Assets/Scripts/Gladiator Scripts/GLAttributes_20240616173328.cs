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

    
    public GladiatorClass Class;
    public int Vitalis;	// Overall health and vitality.	Regeneration, healing spells
    public int Vigor;	// Energy and stamina.	Energy-based attacks, stamina boost
    public int Resolve;	// Mental fortitude and willpower.	Mind resistance, morale boost
    public int Aetherius;	// Innate connection to magic.	Enhanced spell power, mana efficiency
    public int Celerity;	// Speed and agility.	Speed spells, teleportation
    public int Ferocity;	// Aggressiveness and combat prowess.	Berserker state, amplified attacks
    public int Insight;	// Tactical intelligence and awareness.	Precognition, improved spell accuracy
    public int Fortitude;	// Physical and magical resilience.	Protective barriers, elemental resistance
    public int Harmony;	// Balance between physical and magical prowess. Dual-wielding attacks, seamless attack integration
    public int ArcaneMastery;	// Depth of knowledge and skill in ancient magics. Complex spells, magical creature summoning

    //
    public int amount_GotHit;

    //
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
        battleSize = new Vector3(1f,1f,1f);

        //GetComponent<AppereanceManager>().setRace();
        //GetComponent<AppereanceManager>().setRegion();

        HP = max_HP;
    }

    void InitializeClass(GameObject gladiator)
    {
        switch (gladiator.Class)
        {
            case GladiatorClass.Blademaster:
                // Initialize Blademaster-specific behaviors
                break;
            case GladiatorClass.Shieldbearer:
                // Initialize Shieldbearer-specific behaviors
                break;
            case GladiatorClass.Mystic:
                // Initialize Mystic-specific behaviors
                break;
            // Add cases for other classes
        }
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

public enum GladiatorClass
{
    Blademaster,
    Shieldbearer,
    Mystic,
    Elementalist,
    Assassin,
    Beastmaster,
    WarMage,
    Berserker
}
