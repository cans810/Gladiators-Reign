using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayCounterController : MonoBehaviour
{
    public static DayCounterController Instance;

    public GameObject dayCounterObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuScene" || SceneManager.GetActiveScene().name == "BattleScene"){
            dayCounterObject.SetActive(false);
        }
        else{
            dayCounterObject.SetActive(true);

            dayCounterObject.transform.Find("DayCtr").GetComponent<TextMeshProUGUI>().text = GameManager.Instance.currentDay.ToString();
        }
    }
}
