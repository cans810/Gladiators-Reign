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

    public int max_HP;
    public int HP;

    public int max_SP;
    public int SP;

    public int max_MP;
    public int MP;

    public int max_Morale;
    public int Morale;

    public float max_WalkSpeed;
    public float WalkSpeed;


    public GladiatorClass GL_Class;
    public int Vitalis;	  // Overall health and vitality. Regeneration, healing spells
    public int Vigor;	// Energy and stamina. Energy-based attacks, stamina boost
    public int Resolve;	  // Mental fortitude and willpower. Mind resistance, morale boost
    public int Aetherius;	// Innate connection to magic. Enhanced spell power, mana efficiency
    public int Celerity;	// Speed and agility. Speed spells, teleportation
    public int Ferocity;	// Aggressiveness and combat prowess. Berserker state, amplified attacks
    public int Insight;	 // Tactical intelligence and awareness.	Precognition, improved spell accuracy
    public int Fortitude;	// Physical and magical resilience.	Protective barriers, elemental resistance
    public int Harmony;	  // Balance between physical and magical prowess. Dual-wielding attacks, seamless attack integration
    public int ArcaneMastery;	// Depth of knowledge and skill in ancient magics. Complex spells, magical creature summoning
    //
    public int amount_GotHit;
    //
    public int level;
    public float currentXP;
    public float xpToNextLevel;
    //
    public Vector3 battleSize;

    public void InitGladiator(int Vitalis, int Vigor, int Resolve, int Aetherius, int Celerity, int Ferocity, int Insight, int Fortitude, int Harmony, int ArcaneMastery, int level){
        this.Vitalis = Vitalis;
        this.Vigor = Vigor;
        this.Resolve = Resolve;
        this.Aetherius = Aetherius;
        this.Celerity = Celerity;
        this.Ferocity = Ferocity;
        this.Insight = Insight;
        this.Fortitude = Fortitude;
        this.Harmony = Harmony;
        this.ArcaneMastery = ArcaneMastery;
        
        this.level = level;

        VitalisArrange();
        VigorArrange();
        ResolveArrange();
        AetheriusArrange();
        CelerityArrange();

        HP = max_HP;
        SP = max_SP;
        MP = max_MP;
        Morale = max_Morale;
        WalkSpeed = max_WalkSpeed;

        xpToNextLevel = 50;
    }

    public void VitalisArrange(){
        for (int i = 0; i < Vitalis; i++){
            max_HP += Vitalis*2;
        }
    }
    public void VigorArrange(){
        for (int i = 0; i < Vigor; i++){
            max_SP += Vigor*2;
        }
    }
    public void ResolveArrange(){
        for (int i = 0; i < Resolve; i++){
            max_Morale += Resolve*2;
        }
    }
    public void AetheriusArrange(){
        for (int i = 0; i < Aetherius; i++){
            max_MP += Aetherius*2;
        }
    }
    public void CelerityArrange(){
        for (int i = 0; i < Celerity; i++){
            max_WalkSpeed += Celerity*2;
        }
    }

    public void Awake(){
        glManager = GetComponent<GladiatorManager>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        battleSize = new Vector3(2f,2f,2f);
        
        InitializeClass();

        HP = max_HP;
    }

    void InitializeClass()
    {
        switch (GL_Class)
        {
            case GladiatorClass.Blademaster:
                break;
            case GladiatorClass.Shieldbearer:
                break;
            case GladiatorClass.Mystic:
                break;
            case GladiatorClass.Elementalist:
                break;
            case GladiatorClass.Assassin:
                break;
            case GladiatorClass.Beastmaster:
                break;
            case GladiatorClass.WarMage:
                break;
            case GladiatorClass.Berserker:
                break;
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

    public void resetGladiator(){
        HP = max_HP;
        SP = max_SP;
        MP = max_MP;

        glManager.state.dying = false;
        GetComponent<GLState>().alive = true;
        glManager.animationsManager.isAnimating = false;
        glManager.animationsManager.inAction = false;

        GetComponent<AnimationsManager>().StopAction("Death_1");
        GetComponent<AnimationsManager>().StopAction("Death_2");
        GetComponent<AnimationsManager>().StopAction("Death_3");
    }
}

public enum GladiatorClass
{
    Bloodreaver,
    Mystic,
    Shadowblade,
    Wardenguard,
    Spiritcaller,
    Stormbringer,
    Ironclad,
    Battlechanter,
    Soulreaver,
    Bladelord
}

public static class GLClassDescriptions{
    public static string GetDescription(GladiatorClass gladiatorClass)
    {
        switch (gladiatorClass)
        {
            case GladiatorClass.Bloodreaver:
                return "Fierce and relentless fighters who excel in close combat, using their strength and resilience to overpower their enemies.";
            case GladiatorClass.Mystic:
                return "Masters of ancient magics and deep knowledge, they wield powerful spells and summon mystical creatures to aid them in battle.";
            case GladiatorClass.Shadowblade:
                return "A stealthy assassin who strikes from the shadows with deadly precision.";
            case GladiatorClass.Wardenguard:
                return "A stalwart defender who protects allies and holds the line against enemies.";
            case GladiatorClass.Spiritcaller:
                return "A seer who channels the spirits of the past to aid in combat.";
            case GladiatorClass.Stormbringer:
                return "A tempestuous fighter who harnesses the fury of storms to devastate foes.";
            case GladiatorClass.Ironclad:
                return "A heavily armored warrior who excels in defense and fortitude.";
            case GladiatorClass.Battlechanter:
                return "A charismatic leader whose battle cries inspire allies and demoralize enemies.";
            case GladiatorClass.Soulreaver:
                return "A dark force who steals the essence of their enemies to fuel their own power.";
            case GladiatorClass.Bladelord:
                return "A master swordsman whose skills with a blade are unmatched in the arena.";
            default:
                return "No description available.";
        }
    }
}


