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
        if (GetComponent<Attributes>().race.Equals("Human")){
            if (GetComponent<Attributes>().raceRegion.Equals("Eldorian")){
                eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("HumanEyes_Eldorian","eyeNormal");
            }
            if (GetComponent<Attributes>().raceRegion.Equals("Mistvalian")){
                eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("HumanEyes_Mistvalian","eyeNormal");
            }
            if (GetComponent<Attributes>().raceRegion.Equals("Avalorian")){
                eyes.GetComponent<SpriteRenderer>().sprite = textures.GetSprite("HumanEyes_Avalorian","eyeNormal");
            }
        }
            
        // if (gameObject.name.Equals("hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("hair",entity.GetComponent<AppereanceManager>().hair);
        // }
        // if (gameObject.name.Equals("facial_hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("facial_hair",entity.GetComponent<AppereanceManager>().facial_hair);
        // }
    }

    void Update()
    {
        
    }
}
