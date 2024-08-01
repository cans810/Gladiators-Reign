using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonNPCSController : MonoBehaviour
{
    public static DungeonNPCSController Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject findNPCInScene(string npcName){
        GameObject npc = GameObject.Find(npcName);

        return npc;
    }

    public void setBlacksmithActive(bool isActive){
        GameObject blackSmith = findNPCInScene("NPCBlacksmith");
        findNPCInScene("NPCBlacksmith").GetComponent<NPCBlacksmithController>().npcActive = isActive;

        if (isActive == true){
            blackSmith.transform.SetParent(GameObject.Find("NPC's Controller").transform);
        }
        else{
            blackSmith.transform.SetParent(GameObject.Find("Inactive NPCs").transform);
            blackSmith.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void setMultifightArrangerActive(bool isActive){
        findNPCInScene("NPCMultifightArranger").GetComponent<NPCMultifightArrangerController>().npcActive = isActive;

        if (isActive == true){
            blackSmith.transform.SetParent(GameObject.Find("NPC's Controller").transform);
        }
        else{
            blackSmith.transform.SetParent(GameObject.Find("Inactive NPCs").transform);
            blackSmith.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
