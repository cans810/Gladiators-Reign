using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHomeController : MonoBehaviour
{
    public GameObject playerPos;

    // Start is called before the first frame update
    void Start()
    {
        // reset size
        Player.Instance.transform.localScale = Player.Instance.GetComponent<Attributes>().battleSize;
        // set new size
        Player.Instance.transform.localScale *= 2;

        Player.Instance.transform.position = playerPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToDungeonHallButton(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
