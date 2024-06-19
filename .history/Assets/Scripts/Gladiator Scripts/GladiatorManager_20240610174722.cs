using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorManager : MonoBehaviour
{
    // managers
    public Rigidbody2D rb;
    public CommonActions commonActions;
    public BattleAI battleAI;
    public EntitySortingLayerController sortingLayerController;
    public Animator animator;
    public HitBoxManager HitBox;
    public GameObject PopupsManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        commonActions = GetComponent<CommonActions>();
        battleAI = GetComponent<BattleAI>();
        sortingLayerController = GetComponent<EntitySortingLayerController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
