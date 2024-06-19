using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{    
    public void Awake(){
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject playerGL in GameManager.Instance.playerGLs){
            // reset Scale
            playerGL.transform.localScale = playerGL.GetComponent<GLAttributes>().battleSize;

            playerGL.transform.position = playerPos.transform.position;

            Vector3 newRotation = playerGL.transform.rotation.eulerAngles;
            newRotation.y = -180f;
            playerGL.transform.rotation = Quaternion.Euler(newRotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToHome(){
        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }

    public void EnterBattleButton(){
        ScreenFadeController.Instance.FadeToScene("BeforeBattleCellScene");
    }
}
