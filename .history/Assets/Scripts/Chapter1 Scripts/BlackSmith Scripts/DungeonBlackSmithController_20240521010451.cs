using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBlackSmithController : MonoBehaviour
{
    public Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        Player.Instance.gameObject.transform.position = playerPos;

        if (DungeonBlackSmithData.SelectedPart.Equals("Helmet")){
            // prepare helmets
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
