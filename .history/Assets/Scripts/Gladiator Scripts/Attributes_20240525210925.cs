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
    public HitBoxManager HitBox;
    public GameObject PopupsManager;

    public string race;
    public string raceRegion;

    public string gladiator_name;

    public float walk_speed;

    public int max_HP;
    public int HP;


    //
    public bool alive;
    public bool dying;
    public bool inAction;
    public bool isAnimating;
    public bool gotHit;
    public int amount_GotHit;

    //
    public int coin;
    public float fame;
    public int level;
    
    //
    public Vector3 battleSize;

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
        battleSize = gameObject.transform.localScale;

        //GetComponent<AppereanceManager>().setRace();
        //GetComponent<AppereanceManager>().setRegion();

        alive = true;
        dying = false;
        HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            if (HP <= 0){
                dying = true;
            }
            else{
                dying = false;
            }
        }

        if (!isAnimating && !inAction && !SceneManager.GetActiveScene().name.Equals("BattleScene")){
            animator.SetBool("Idle",true);
        }
        else{
            animator.SetBool("Idle",false);
        }

        if (battleAI.currentActionKey != "GetKilled" && dying && alive){
            battleAI.actionQueue.ClearQueue();
            battleAI.actionQueue.Enqueue("CommonActions","GetKilled",false,true);
        }
    }

    public void ChangeMaterial(Material newMaterial)
    {
        if (newMaterial == null)
        {
            Debug.LogWarning("New material is not assigned.");
            return;
        }

        // Start the recursive search from the root object
        ChangeMaterialRecursive(transform);
    }

    private void ChangeMaterialRecursive(Transform parent, Material newMaterial)
    {
        // Get the SpriteRenderer component on the current object
        SpriteRenderer spriteRenderer = parent.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.material = newMaterial;
        }

        // Recursively search through all children
        foreach (Transform child in parent)
        {
            ChangeMaterialRecursive(child);
        }
    }
}
