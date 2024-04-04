using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInfoTabController : MonoBehaviour
{
    public TextMeshProUGUI playerName;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = Player.Instance.GetComponent<Attributes>().name;
    }
}
