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

            var gladiator = GameManager.Instance.playerGLs[i];
            adjustGladiatorTransform(gladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));

            var clickable = gladiator.GetComponent<ClickableObject>();
            if (clickable != null)
            {
                clickable.onClick.RemoveAllListeners();  // Clear any existing listeners

                clickable.onClick.AddListener(() => OnGladiatorClickActions(gladiator));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
