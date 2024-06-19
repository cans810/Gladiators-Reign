using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChosenPart : MonoBehaviour
{
    public bool partClickable;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DungeonScene"){
            partClickable = true;
            //boxCollider2D.enabled = true;
        }
        else{
            partClickable = false;
            //boxCollider2D.enabled = false;
        }
    }

    public void selectPart(){
        if (partClickable){
            Debug.Log("clicked " + gameObject.name);
        }
    }
}
