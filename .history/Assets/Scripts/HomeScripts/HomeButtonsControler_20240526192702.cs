using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonsControler : MonoBehaviour
{
    public GameObject PlayerInfoTab;

    public GameObject PlayerEquipmentTab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPlayerInfoTab(){
        PlayerInfoTab.SetActive(true);
    }

    public void OpenEquipmentTab(){
        PlayerInfoTab.SetActive(true);
    }

    public void GoToTown(){
        SceneManager.LoadScene("TownScene");
    }
}
