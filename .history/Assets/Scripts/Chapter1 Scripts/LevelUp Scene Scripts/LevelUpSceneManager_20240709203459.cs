using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpSceneManager : MonoBehaviour
{
    public GameObject glPos;
    public static GameObject LeveledUp_Gl;

    public TextMeshProUGUI glNameTMP;
    public TextMeshProUGUI classTMP;

    // Start is called before the first frame update
    void Start()
    {
        LeveledUp_Gl.transform.position = glPos.transform.position;

        glNameTMP.text = LeveledUp_Gl.GetComponent<GLAttributes>().gladiator_name;
        classTMP.text = LeveledUp_Gl.GetComponent<GLAttributes>().GL_Class.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
