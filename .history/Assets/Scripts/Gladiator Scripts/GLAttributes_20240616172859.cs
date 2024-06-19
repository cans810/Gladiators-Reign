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

    Vitalis	Overall health and vitality.	Regeneration, healing spells
Vigor	Energy and stamina.	Energy-based attacks, stamina boost
Resolve	Mental fortitude and willpower.	Mind resistance, morale boost
Aetherius	Innate connection to magic.	Enhanced spell power, mana efficiency
Celerity	Speed and agility.	Speed spells, teleportation
Ferocity	Aggressiveness and combat prowess.	Berserker state, amplified attacks
Insight	Tactical intelligence and awareness.	Precognition, improved spell accuracy
Fortitude	Physical and magical resilience.	Protective barriers, elemental resistance
Harmony	Balance between physical and magical prowess.	Dual-wielding attacks, seamless attack integration
Arcane Mastery	Depth of knowledge and skill in ancient magics.	Complex spells, magical creature summoning

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
        battleSize = new Vector3(1f,1f,1f);

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
