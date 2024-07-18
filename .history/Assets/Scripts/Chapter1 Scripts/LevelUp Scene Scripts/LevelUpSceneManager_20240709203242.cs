using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSceneManager : MonoBehaviour
{
    public GameObject glPos;
    public static GameObject LeveledUp_Gl;

    

    // Start is called before the first frame update
    void Start()
    {
        LeveledUp_Gl.transform.position = glPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
