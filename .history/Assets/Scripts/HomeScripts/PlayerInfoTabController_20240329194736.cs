using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoTabController : MonoBehaviour
{
    public TextMeshProUGUI playerName;

    public void Awake(){
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = Player.Instance.GetComponent<Attributes>().name;
    }

    public void CloseTab(){
        gameObject.SetActive(False)
    }
}
