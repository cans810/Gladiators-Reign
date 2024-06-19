using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterChosenPart : MonoBehaviour
{
    public bool partClickable;
    public BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "DungeonScene"){
            partClickable = true;
        }
        else{
            partClickable = false;
            boxCollider2D.enabled = true;
        }
    }

    public void selectPart(){
        if (partClickable){
            boxCollider2D.enabled = true;
        }
    }
}
