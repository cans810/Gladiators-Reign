using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            var gladiator = GameManager.Instance.playerGLs[i];
            adjustGladiatorTransform(gladiator, new Vector3(-100, -100, -100));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void adjustGladiatorTransform(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(3f, 3f, 3f);
    }

    public void GoToHome(){
        ScreenFadeController.Instance.FadeToScene("DungeonHomeScene");
    }

    public void GoToRTrainingSection(){
        ScreenFadeController.Instance.FadeToScene("DungeonTrainingScene");
    }
}
