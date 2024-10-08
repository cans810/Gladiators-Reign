using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLEffectsManager : MonoBehaviour
{
    private GameObject gladiator;

    public GladiatorManager glManager;

    public Material leveledUpEffect;

    // Start is called before the first frame update
    void Start()
    {
        gladiator = transform.parent.gameObject;

        glManager = gladiator.GetComponent<GladiatorManager>();

        glManager.ChangeMaterial(leveledUpEffect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
