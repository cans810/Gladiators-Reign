using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GLAttributes : MonoBehaviour
{
    GladiatorManager gladiatorManager;

    public string race;
    public string raceRegion;

    public string gladiator_name;

    public float walk_speed;

    public int max_HP;
    public int HP;


    //
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

        HP = max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            if (HP <= 0){
                gladiatorManager.gladiatorState.dying = true;
            }
            else{
                dying = false;
            }
        }

        if (!gladiatorManager.animationsManager.isAnimating && !gladiatorManager.animationsManager.inAction && !SceneManager.GetActiveScene().name.Equals("BattleScene")){
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
