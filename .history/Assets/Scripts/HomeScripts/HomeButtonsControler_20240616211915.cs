using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButtonsControler : MonoBehaviour
{
    public GameObject PlayerEquipmentTab;

    // Start is called before the first frame update
    void Start()
    {
        PlayerEquipmentTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenEquipmentTab(){
        PlayerEquipmentTab.SetActive(true);
    }

    public void GoToTown(){
        SceneManager.LoadScene("TownScene");
    }
}
