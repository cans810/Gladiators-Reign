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
        else if (GetComponent<Attributes>().race.Equals("Elf")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("ElfEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("ElfNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("ElfMouth","mouthNormal");
        }
        else if (GetComponent<Attributes>().race.Equals("Eastern Human")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("EasternHumanEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("EasternHumanNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("EasternHumanMouth","mouthNormal");
        }
        else if (GetComponent<Attributes>().race.Equals("Orc")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("OrcEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("OrcNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("OrcMouth","mouthNormal");
        }
        else if (GetComponent<Attributes>().race.Equals("Troll")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("TrollEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("TrollNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("TrollMouth","mouthNormal");
        }
        else if (GetComponent<Attributes>().race.Equals("Demon")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("DemonEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("DemonNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("DemonMouth","mouthNormal");
        }

        else if (GetComponent<Attributes>().race.Equals("Wraith")){
            eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("WraithEyes","eyeNormal");
            nose.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("DemonNose","nose");
            mouth.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("DemonMouth","mouthNormal");
        }

        // if (gameObject.name.Equals("hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("hair",entity.GetComponent<AppereanceManager>().hair);
        // }
        // if (gameObject.name.Equals("facial_hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("facial_hair",entity.GetComponent<AppereanceManager>().facial_hair);
        // }
    }
}
