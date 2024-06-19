using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour
{
    public GameObject playerPos;

    // Start is called before the first frame update
    void Start()
    {
        // reset Scale
        Player.Instance.transform.localScale = Player.Instance.GetComponent<GLAttributes>().battleSize;
        // set new Scale
        Player.Instance.transform.localScale *= 2;

        Player.Instance.GetComponent<AnimationsManager>().StartAnim("RestCampfire");
        Player.Instance.transform.position = playerPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
