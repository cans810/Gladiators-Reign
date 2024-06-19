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

    public void create_GLInfoTab()
    {
        GameObject canvas = null;
        if (SceneManager.GetActiveScene().name == "FirstGladiatorSelectionScene")
        {
            canvas = GameObject.Find("GladiatorSelectionCanvas");
        }

        GameObject GLInfoTab = Instantiate(GLInfoTabPrefab); 
        GLInfoTab.transform.SetParent(canvas.transform);

        // Reset the transform components
        GLInfoTab.transform.localPosition = Vector3.zero;
        GLInfoTab.transform.localRotation = Quaternion.identity;
        GLInfoTab.transform.localScale = Vector3.one;
    }

}
