using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingController : MonoBehaviour
{
    public GameObject playerPos;

    public int gladiatorSpacing;

    public GameObject selectedGladiator;

    public List<GameObject> trainingGLs;

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
            adjustGladiatorTransform(gladiator, new Vector3(-100,-100,-100));

            if (GameManager.Instance.playerGLs[i].GetComponent<GLState>().isTraining){
                trainingGLs.Add(GameManager.Instance.playerGLs[i]);
            }
        }

        // set gl transform
        float totalWidth = (trainingGLs.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = playerPos.transform.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < trainingGLs.Count; i++)
        {
            if (i >= trainingGLs.Count)
            {
                continue;
            }

            var gladiator = trainingGLs[i];
            adjustGladiatorTransform(gladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));

            var clickable = gladiator.GetComponent<ClickableObject>();
            if (clickable != null)
            {
                //clickable.onClick.RemoveAllListeners();  // Clear any existing listeners

                //clickable.onClick.AddListener(() => OnGladiatorClickActions(gladiator));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check if training of a gladiator is finished.
        foreach (GameObject gl in trainingGLs){
            if (!gl.GetComponent<GLState>().isTraining){
                adjustGladiatorTransform(gl, new Vector3(-100,-100,-100));
                giveTrainingRewards(gl);
                trainingGLs.Remove(gl);
            }
        }
    }

    public void giveTrainingRewards(GameObject gladiator){
        gladiator.GetComponent<GladiatorManager>().giveXP(10) += 10;
    }

    public void adjustGladiatorTransform(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public void GoBackButton(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }
}
