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

    public GLEffectsManager gLEffectsManager;

    public GameObject GLInfoTabPrefab;
    public GameObject GLActionsTabPrefab;

    public GameObject skillPopupPrefab;


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
        // if (SceneManager.GetActiveScene().name.Equals("BattleScene"))
        // {
        //     commonActions.enabled = true;
        //     battleAI.enabled = true;
        // }
        // else
        // {
        //     commonActions.enabled = false;
        //     battleAI.enabled = false;
        // }
    }

    public Transform GetBodyPartPos(string bodyPartName){
        GameObject model = transform.Find("GladiatorModel").gameObject;

        foreach (Transform bodyPart in model.transform){
            if (bodyPart.name == bodyPartName){
                return bodyPart;
            }
        }
        return null;
    }

    public void RemoveClickables(){
        var clickable = gameObject.GetComponent<ClickableObject>();
        if (clickable != null)
        {
            clickable.onClick.RemoveAllListeners();  // Clear any existing listeners
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

    public void create_GLInfoTab(Transform glInfoTabPos)
    {
        GameObject canvas = null;
        if (SceneManager.GetActiveScene().name == "FirstGladiatorSelectionScene")
        {
            canvas = GameObject.Find("GladiatorSelectionCanvas");
        }

        GameObject GLInfoTab = Instantiate(GLInfoTabPrefab); 
        GLInfoTab.GetComponent<GLInfoTabManager>().GLBelongTo = gameObject;
        GLInfoTab.transform.SetParent(canvas.transform);

        // Reset the transform components
        GLInfoTab.GetComponent<GLInfoTabManager>().setPosition();
        GLInfoTab.transform.localRotation = Quaternion.identity;
        GLInfoTab.transform.localScale = new Vector3(5f, 5f, 5f);
        GLInfoTab.transform.position = glInfoTabPos.position;
    }

    public void create_GLActionsTab()
    {
        GameObject canvas = null;
        if (SceneManager.GetActiveScene().name == "DungeonHomeScene")
        {
            canvas = GameObject.Find("HomeCanvas");
        }

        GameObject GLActionsTab = Instantiate(GLActionsTabPrefab); 
        GLActionsTab.GetComponent<GLActionsTabManager>().GLBelongTo = gameObject;
        GLActionsTab.transform.SetParent(canvas.transform);

        // Reset the transform components
        GLActionsTab.GetComponent<GLActionsTabManager>().setPosition();
        GLActionsTab.transform.localRotation = Quaternion.identity;
        GLActionsTab.transform.localScale = new Vector3(4f, 4f, 4f);
    }

    public void SetAnimationSpeed(string animationName, float speed)
    {
        AnimatorOverrideController overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        foreach (var clipPair in overrideController.animationClips)
        {
            if (clipPair.name == animationName)
            {
                animator.speed = speed;
                break;
            }
        }
    }

}
