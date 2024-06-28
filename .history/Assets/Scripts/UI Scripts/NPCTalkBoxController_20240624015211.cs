using UnityEngine;

public class NPCTalkBoxController : MonoBehaviour
{
    public GameObject NPC;

    // Start is called before the first frame update
    void Start()
    {
        NPC_Talk(NPC);
    }

    public void NPC_Talk(GameObject NPC)
    {
        if (NPC != null)
        {
            var sellerController = NPC.GetComponent<MysteriousSellerController>();
            if (sellerController != null)
            {
                sellerController.StartTalking();
            }
        }
    }
}
