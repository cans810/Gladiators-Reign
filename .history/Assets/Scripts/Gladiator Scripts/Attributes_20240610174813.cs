using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attributes : MonoBehaviour
{
    GladiatorManager gladiatorManager;

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
        gladiatorManager = GetComponent<GladiatorManager>();
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
            gladiatorManager.animator.SetBool("Idle",true);
        }
        else{
            gladiatorManager.animator.SetBool("Idle",false);
        }

        if (gladiatorManager.battleAI.currentActionKey != "GetKilled" && dying && alive){
            gladiatorManager.battleAI.actionQueue.ClearQueue();
            gladiatorManager.battleAI.actionQueue.Enqueue("CommonActions","GetKilled",false,true);
        }
    }

    public void ChangeMaterial(Material newMaterial)
    {
        if (newMaterial == null)
        {
            Debug.LogWarning("New material is not assigned.");
            return;
        }

        ChangeMaterialRecursive(transform, newMaterial);
    }

    private void ChangeMaterialRecursive(Transform parent, Material newMaterial)
    {
        SpriteRenderer spriteRenderer = parent.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.material = newMaterial;
        }

        foreach (Transform child in parent)
        {
            ChangeMaterialRecursive(child, newMaterial);
        }
    }
}
