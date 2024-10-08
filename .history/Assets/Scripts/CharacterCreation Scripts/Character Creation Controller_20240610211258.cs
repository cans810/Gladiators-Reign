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
        Player.Instance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;       
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
        Player.Instance.GetComponent<GLAttributes>().gladiator_name = NameInput.text;

        SceneManager.LoadScene("BattleScene");
    }

    public void continueToTownButton(){
        Player.Instance.GetComponent<GLAttributes>().gladiator_name = NameInput.text;

        ScreenFadeController.Instance.FadeToScene("TownScene");
    }

    public void continueToDungeonHomeButton(){
        GameManager.Instance.startTimer = true;

        Player.Instance.GetComponent<GLAttributes>().gladiator_name = NameInput.text;

        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }
}
