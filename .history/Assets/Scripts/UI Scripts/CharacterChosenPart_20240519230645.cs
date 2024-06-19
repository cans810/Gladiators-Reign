using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChosenPart : MonoBehaviour
{
    public bool partClickable;
    public Box

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DungeonScene"){
            partClickable = true;
        }
        else{
            partClickable = false;
        }
    }

    public void selectPart(){
        if (partClickable){


        }
    }
}
