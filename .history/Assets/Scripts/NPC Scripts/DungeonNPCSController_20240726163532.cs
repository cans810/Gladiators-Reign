using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonNPCSController : MonoBehaviour
{
    public GameObject BlackSmithPrefab;
    public GameObject MultiFightArrangerPrefab;

    public static DungeonNPCSController Instance;

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
