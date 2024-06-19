using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSmithController : MonoBehaviour
{
    public GameObject BlackSmithChatBox;

    public GameObject PlayerStandCanvas;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStandCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Dungeons_BlackSmithInteraction()
    {
        Player.Instance.GetComponent<CommonActions>().WalkToPoint(gameObject.transform.Find("playerPos").transform.position,3.5f);

        Camera.main.GetComponent<Animator>().SetBool("ZoomOnBlackSmith", true);
    }

    public void Dungeons_BattleArrangerClosed()
    {
        PlayerStandCanvas.SetActive(false);

        Player.Instance.GetComponent<CommonActions>().WalkToPoint(GameObject.Find("DungeonControllerCanvas").transform.Find("playerPos").transform.position,3.5f);
        
        Camera.main.GetComponent<Animator>().SetBool("ZoomOnBattleArranger", false);
    }

    IEnumerator WaitForPlayer(bool value){
        yield return new WaitForSeconds(1.1f);

        PlayerStandCanvas.SetActive(value);
    }
}
