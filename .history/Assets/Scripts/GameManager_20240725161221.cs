using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> playerGLs = new List<GameObject>();
    public List<GameObject> playerInventory = new List<GameObject>();
    public int coins;

    public bool startTimer;

    public bool completedChapter1;

    public float elapsedTimeInSeconds; // Track elapsed time in seconds
    public int currentDay = 0; // Track current day

    public bool recentlyFought;

    public GameObject gladiatorSelectedForFight;
    public List<GameObject> gladiatorsSelectedForFight;

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
    
    private void Update()
    {
        if(startTimer){
            elapsedTimeInSeconds += Time.deltaTime;

            // check if a day has passed (1 minute in real time = 1 day in game time)
            if (elapsedTimeInSeconds >= 60) // 60 seconds = 1 minute
            {
                elapsedTimeInSeconds -= 60; // reset elapsed time for the next day
                currentDay++; // increment current day
                Debug.Log("Day " + currentDay); // output current day (you can replace this with your own logic)
            }
        }

        if (SceneManager.GetActiveScene().name == "ArenaScene")
        {
            
        }
    }


    public bool isTimeForBattle(){
        if (GameManager.Instance.currentDay % 2 == 0){
            return true;
        }
        return false;
    }

    public IEnumerator RecentlyFoughtCoroutine(){
        recentlyFought = true;
        
        // should rest for a day after fighting.
        yield return new WaitForSeconds(60f);
        
        recentlyFought = false;
    }
}