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

        GL_Class
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

    public void SetClass(){}

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
                return "Stealthy and agile assassins who strike from the shadows with deadly precision, using their speed and cunning to outmaneuver opponents.";
            case GladiatorClass.Wardenguard:
                return "Defenders and protectors who specialize in creating protective barriers and enhancing their allies' defenses with magical and physical resilience.";
            case GladiatorClass.Spiritcaller:
                return "Channelers of spiritual energy who can heal, resurrect, and summon ethereal beings to support their allies in combat.";
            case GladiatorClass.Stormbringer:
                return "Conduits of elemental forces, they unleash devastating elemental spells and harness the power of storms to obliterate their enemies.";
            case GladiatorClass.Ironclad:
                return "Heavy-armored warriors who use their immense strength and durability to endure and counter even the fiercest attacks.";
            case GladiatorClass.Battlechanter:
                return "Warriors who blend combat and magic seamlessly, enchanting their weapons and enhancing their physical prowess with arcane power.";
            case GladiatorClass.Soulreaver:
                return "Fearsome combatants who feed off the life force of their enemies, growing stronger and more ferocious with each kill.";
            case GladiatorClass.Bladelord:
                return "Master swordsmen who combine speed, strength, and precision, making them lethal in both offense and defense.";
            default:
                return "No description available.";
        }
    }
}


