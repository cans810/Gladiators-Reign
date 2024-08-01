using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonNPCSController : MonoBehaviour
{
    public GameObject BlackSmithPrefab;
    public GameObject MultiFightArrangerPrefab;
    
    public static GameManager Instance;

    public List<GameObject> playerGLs = new List<GameObject>();
    public List<GameObject> playerInventory = new List<GameObject>();
    public int coins;

    public bool startTimer;

    public bool completedChapter1;

    public float elapsedTimeInSeconds; // Track elapsed time in seconds
    public int currentDay = 0; // Track current day

    public bool recentlyFought;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
