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

    void Update()
    {
        // if (gameObject.name.Equals("hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("hair",entity.GetComponent<AppereanceManager>().hair);
        // }
        // if (gameObject.name.Equals("facial_hair")){
        //     GetComponent<SpriteRenderer>().sprite = textures.GetSprite("facial_hair",entity.GetComponent<AppereanceManager>().facial_hair);
        // }
    }
}
