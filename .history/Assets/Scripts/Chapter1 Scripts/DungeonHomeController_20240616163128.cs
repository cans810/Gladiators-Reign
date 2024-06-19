using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonHomeController : MonoBehaviour
{
    public GameObject playerPos;
    public int gladiatorSpacing;

    // Start is called before the first frame update
    void Start()
    {
        // // reset size
        // Player.Instance.transform.localScale = Player.Instance.GetComponent<GLAttributes>().battleSize;
        // // set new size
        // Player.Instance.transform.localScale *= 2;

        // Player.Instance.transform.position = playerPos.transform.position;

        float totalWidth = (GameManager.Instance.playerGLs.Count - 1) * gladiatorSpacing;
        Vector3 startPosition = GameManager.Instance.playerGLs.Count.position - new Vector3(totalWidth / 2, +2, 0);

        for (int i = 0; i < GameManager.Instance.playerGLs.Count; i++)
        {
            GameObject generatedGladiator = GameObject.Instantiate(gladiatorPrefab);
            setRandomRace(generatedGladiator);
            adjustGladiatorAfterSpawn(generatedGladiator, startPosition + new Vector3(i * gladiatorSpacing, 0, 0));


            generatedGladiator.GetComponent<ClickableObject>().onClick.AddListener(() => OnGladiatorClick(generatedGladiator));

            generatedGladiators.Add(generatedGladiator);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToDungeonHallButton(){
        ScreenFadeController.Instance.FadeToScene("DungeonScene");
    }

    public void adjustGladiatorTransform(GameObject gladiator, Vector3 position)
    {
        gladiator.transform.position = position;
        gladiator.transform.localScale = new Vector3(3f, 3f, 3f);
    }
}
