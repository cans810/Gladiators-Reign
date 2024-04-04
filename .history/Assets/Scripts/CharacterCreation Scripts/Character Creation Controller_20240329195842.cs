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

    public TextMeshProUGUI NameInput;

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
        RaceSelection.SetActive(true);
    }

    public void continueToFirstBattle(){
        Player.Instance.GetComponent<Attributes>().gladiator_name = NameInput.text;

        SceneManager.LoadScene("BattleScene");
    }
}
