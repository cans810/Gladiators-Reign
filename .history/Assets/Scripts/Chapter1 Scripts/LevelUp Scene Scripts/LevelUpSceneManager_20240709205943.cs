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

    public GameObject VitalisBtn;
    public GameObject VigorBtn;
    public GameObject ResolveBtn;
    public GameObject AetheriusBtn;
    public GameObject CelerityBtn;
    public GameObject VitalisBtn;
    public GameObject VitalisBtn;
    public GameObject VitalisBtn;
    public GameObject VitalisBtn;
    public GameObject VitalisBtn;
    public GameObject VitalisBtn;

    // Start is called before the first frame update
    void Start()
    {
        LeveledUp_Gl.transform.position = glPos.transform.position;

        glNameTMP.text = LeveledUp_Gl.GetComponent<GLAttributes>().gladiator_name;
        classTMP.text = LeveledUp_Gl.GetComponent<GLAttributes>().GL_Class.ToString();


    }

    public void setButtons(){
        if (classTMP.text.Equals("Bloodreaver")){
            Vitalis, Vigor, Ferocity, Fortitude, Resolve
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
