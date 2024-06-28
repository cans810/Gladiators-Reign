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

    public GameObject GLInfoTabPrefab;
    public GameObject GLActionsTabPrefab;

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
        GLInfoTab.transform.localScale = new Vector3(6f, 6f, 6f);
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

}
