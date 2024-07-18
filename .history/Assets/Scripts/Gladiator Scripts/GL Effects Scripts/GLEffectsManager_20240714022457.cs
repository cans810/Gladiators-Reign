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
    

    // Start is called before the first frame update
    void Start()
    {
        
        gladiator = transform.parent.gameObject;

        glManager = gladiator.GetComponent<GladiatorManager>();
    }

    public void Normal(){
        glManager.ChangeMaterial(normal);
    }

    public void LeveledUpEffect(){
        glManager.ChangeMaterial(leveledUpEffect);
    }

    public void BloodSpashEffect(Transform position){
        pixelBloodEffect.Emit(position.position);
    }
}


}
