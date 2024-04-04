using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterCreationController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.GetComponent<Rigidbody2D>.constraints = RigidbodyConstraints2D.FreezePosition;       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continueToFirstBattle(){
        SceneManager.LoadScene("BattleScene");
    }
}
