using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class FacialFeatureManager : MonoBehaviour
{
    public GameObject eyes;
    public GameObject nose;
    public GameObject mouth;
    public SpriteLibraryAsset textures;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (GetComponent<Attributes>().race.Equals("Human")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("HumanEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("HumanNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("HumanMouth","mouthNormal");
        }
        if (GetComponent<Attributes>().race.Equals("Elf")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("ElfEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("ElfNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("HumanMouth","mouthNormal");
        }

        // if (gameObject.name.Equals("hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("hair",entity.GetComponent<AppereanceManager>().hair);
        // }
        // if (gameObject.name.Equals("facial_hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("facial_hair",entity.GetComponent<AppereanceManager>().facial_hair);
        // }
    }
}
