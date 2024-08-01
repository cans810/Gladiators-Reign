using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLEffectsManager : MonoBehaviour
{
    private GameObject gladiator;

    public GladiatorManager glManager;

    public PixelBloodEffect pixelBloodEffect;

    public Material normal;

    public Material leveledUpEffect;
    public GameObject healPlusPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
        gladiator = transform.parent.gameObject;

        glManager = gladiator.GetComponent<GladiatorManager>();

        pixelBloodEffect = GetComponent<PixelBloodEffect>();
    }

    public void Normal(){
        glManager.ChangeMaterial(normal);
    }

    public void LeveledUpEffect(){
        glManager.ChangeMaterial(leveledUpEffect);
    }

    public void BloodSpashEffect(Transform bodyPart){
        pixelBloodEffect.Emit(bodyPart);
    }

    public void NormalHealEffect(Transform bodyPart){
        GameObject healPlus = Instantiate(healPlusPrefab);
    }
}
