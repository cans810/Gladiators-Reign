using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonArenaController : MonoBehaviour
{

    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            if (i >= GameManager.Instance.playerGLs.Count)
            {
                continue;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
