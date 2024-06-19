using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonArenaController : MonoBehaviour
{

    public Transform playerPos;
    public int gladiatorSpacing;

    // Start is called before the first frame update
    void Start()
    {
        float totalWidth = (GameManager.Instance.playerGLs.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            if (i >= GameManager.Instance.playerGLs.Count)
            {
                continue;
            }
            GameManager.Instance.playerGLs[i].transform.position 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
