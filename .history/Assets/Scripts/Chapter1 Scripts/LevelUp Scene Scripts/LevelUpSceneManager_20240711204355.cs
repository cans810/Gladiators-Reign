using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpSceneManager : MonoBehaviour
{
    public int totalPoints;

    public GameObject glPos;
    public static GameObject LeveledUp_Gl;

    public TextMeshProUGUI glNameTMP;
    public TextMeshProUGUI classTMP;

    public GameObject VitalisBtn;
    public GameObject VigorBtn;
    public GameObject ResolveBtn;
    public GameObject AetheriusBtn;
    public GameObject CelerityBtn;
    public GameObject FerocityBtn;
    public GameObject InsightBtn;
    public GameObject FortitudeBtn;
    public GameObject HarmonyBtn;
    public GameObject ArcaneMasteryBtn;

    public GameObject continueButton;
    public bool pointsFinished;

    public GameObject AttributesCanvas;
    public GameObject SkillTreeCanvas;

    public GameObject selectedSkill;


    // Start is called before the first frame update
    void Start()
    {
        SkillTreeCanvas.SetActive(false);

        LeveledUp_Gl.GetComponent<GladiatorManager>().gLEffectsManager.Normal();

        LeveledUp_Gl.transform.position = glPos.transform.position;

        glNameTMP.text = LeveledUp_Gl.GetComponent<GLAttributes>().gladiator_name;
        classTMP.text = LeveledUp_Gl.GetComponent<GLAttributes>().GL_Class.ToString();

        VitalisBtn.SetActive(false);
        VigorBtn.SetActive(false);
        ResolveBtn.SetActive(false);
        AetheriusBtn.SetActive(false);
        CelerityBtn.SetActive(false);
        FerocityBtn.SetActive(false);
        InsightBtn.SetActive(false);
        FortitudeBtn.SetActive(false);
        HarmonyBtn.SetActive(false);
        ArcaneMasteryBtn.SetActive(false);

        continueButton.SetActive(false);
        pointsFinished = false;

        setButtons();

        // remove clickables
        LeveledUp_Gl.GetComponent<GladiatorManager>().RemoveClickables();
    }
    
    public void Update(){
        if (totalPoints <= 0 && !pointsFinished){
            VitalisBtn.SetActive(false);
            VigorBtn.SetActive(false);
            ResolveBtn.SetActive(false);
            AetheriusBtn.SetActive(false);
            CelerityBtn.SetActive(false);
            FerocityBtn.SetActive(false);
            InsightBtn.SetActive(false);
            FortitudeBtn.SetActive(false);
            HarmonyBtn.SetActive(false);
            ArcaneMasteryBtn.SetActive(false);

            continueButton.SetActive(true);
            pointsFinished = true;
        }
    }

    public void setButtons(){
        if (classTMP.text.Equals("Bloodreaver")){
            VitalisBtn.SetActive(true);
            VigorBtn.SetActive(true);
            FerocityBtn.SetActive(true);
            FortitudeBtn.SetActive(true);
            ResolveBtn.SetActive(true);
            //Vitalis, Vigor, Ferocity, Fortitude, Resolve
        }
    }

    public void givePoints_Vitalis(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Vitalis += 1;
        totalPoints -= 1;
    }
    public void givePoints_Vigor(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Vigor += 1;
        totalPoints -= 1;
    }
    public void givePoints_Resolve(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Resolve += 1;
        totalPoints -= 1;
    }
    public void givePoints_Aetherius(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Aetherius += 1;
        totalPoints -= 1;
    }
    public void givePoints_Celerity(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Celerity += 1;
        totalPoints -= 1;
    }
    public void givePoints_Ferocity(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Ferocity += 1;
        totalPoints -= 1;
    }
    public void givePoints_Insight(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Insight += 1;
        totalPoints -= 1;
    }
    public void givePoints_Fortitude(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Fortitude += 1;
        totalPoints -= 1;
    }
    public void givePoints_Harmony(){
        LeveledUp_Gl.GetComponent<GLAttributes>().Harmony += 1;
        totalPoints -= 1;
    }
    public void givePoints_ArcaneMastery(){
        LeveledUp_Gl.GetComponent<GLAttributes>().ArcaneMastery += 1;
        totalPoints -= 1;
    }

    public void continueButtonClicked(){
        AttributesCanvas.SetActive(false);
        SkillTreeCanvas.SetActive(true);

        activateSkillTree(LeveledUp_Gl.GetComponent<GLAttributes>().GL_Class, SkillTreeCanvas);

        LeveledUp_Gl.GetComponent<GLState>().levelUpHandled = false;
        LeveledUp_Gl.GetComponent<GLState>().waitingForLevelup = false;
    }

    public void activateSkillTree(GladiatorClass glClass, GameObject skillTreeCanvas){
        GameObject glSkillTree = null;
        
        if (glClass == GladiatorClass.Bloodreaver){
            glSkillTree = skillTreeCanvas.transform.Find("BloodreaverSkillTree").gameObject;
        }

        foreach (Transform child in skillTreeCanvas.transform)
        {
            if (child.gameObject != glSkillTree){
                child.gameObject.SetActive(false);
            }
        }
    }

    public void acquireSelectedSkill(){
        GladiatorClass glClass = LeveledUp_Gl.GetComponent<GLAttributes>().GL_Class;

        GameObject glSkillTree;

        if (glClass == GladiatorClass.Bloodreaver){
            glSkillTree = SkillTreeCanvas.transform.Find("BloodreaverSkillTree").gameObject;

            foreach (GameObject skill in glSkillTree.transform){
                
                LeveledUp_Gl.GetComponent<GLBattleAI>().AddSkill("BloodReaver_RavagersCleave");
            }
        }
    }

    
}
