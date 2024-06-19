using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GladiatorManager : MonoBehaviour
{
    // managers
    public Rigidbody2D rb;
    public GLCommonActions commonActions;
    public GLBattleAI battleAI;
    public EntitySortingLayerController sortingLayerController;
    public Animator animator;
    public HitBoxManager HitBox;
    public GameObject PopupsManager;
    public AnimationsManager animationsManager;
    public GLState state;
    public GLAttributes attributes;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        commonActions = GetComponent<GLCommonActions>();
        battleAI = GetComponent<GLBattleAI>();
        sortingLayerController = GetComponent<EntitySortingLayerController>();
        animator = GetComponent<Animator>();
        animationsManager = GetComponent<AnimationsManager>();
        state = GetComponent<GLState>();
        attributes = GetComponent<GLAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.)
    }
}
