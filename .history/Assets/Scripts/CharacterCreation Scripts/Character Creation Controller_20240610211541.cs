using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreationController : MonoBehaviour
{
    public GameObject RaceSelection;
    public GameObject EnterName;

    public TMP_InputField NameInput;

    public void Awake(){
        RaceSelection.SetActive(true);
        EnterName.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continueToEnterName(){
        RaceSelection.SetActive(false);
        EnterName.SetActive(true);
    }

    public void continueToFirstBattle(){
        SceneManager.LoadScene("BattleScene");
    }

    public void continueToTownButton(){
        ScreenFadeController.Instance.FadeToScene("TownScene");
    }

    public void continueToDungeonHomeButton(){
        GameManager.Instance.startTimer = true;
        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }
}
