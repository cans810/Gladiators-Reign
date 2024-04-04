using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterCreationController : MonoBehaviour
{
    public GameObject RaceSelection;
    public GameObject EnterName;

    public InputField NameInput;

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
        SceneManager.LoadScene("BattleScene");
        Player.Instance.
    }
}
