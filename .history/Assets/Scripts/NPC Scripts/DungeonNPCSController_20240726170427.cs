using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name.Equals("DungeonScene")){
            if (GameManager.Instance.currentDay % 2 == 0){
                setBlacksmithActive(true);
                setMultifightArrangerActive(false);
            }
            else if (GameManager.Instance.currentDay % 2 == 1){
                setBlacksmithActive(false);
                setMultifightArrangerActive(true);
            }
        }
        else
        {
            Transform blackSmithTransform = transform.Find("NPCBlacksmith");
            if (blackSmithTransform != null)
            {
                GameObject blackSmith = blackSmithTransform.gameObject;
                blackSmith.GetComponent<NPCBlacksmithController>().npcActive = false;
                blackSmith.transform.SetParent(null);
            }
            else
            {
                Debug.LogWarning("NPCBlacksmith not found");
            }

            Transform multiFightArrangerTransform = transform.Find("NPCMultifightArranger");
            if (multiFightArrangerTransform != null)
            {
                GameObject multiFightArranger = multiFightArrangerTransform.gameObject;
                multiFightArranger.GetComponent<NPCMultifightArrangerController>().npcActive = false;
                multiFightArranger.transform.SetParent(null);
            }
            else
            {
                Debug.LogWarning("NPCMultifightArranger not found");
            }
        }
    }

    public void setBlacksmithActive(bool isActive){
        GameObject blackSmith = findNPCInScene("NPCBlacksmith");
        blackSmith.GetComponent<NPCBlacksmithController>().npcActive = isActive;

        if (isActive == true){
            blackSmith.transform.SetParent(GameObject.Find("NPC's Controller").transform);
        }
        else{
            GameObject inactiveNPCCanvas = GameObject.Find("Inactive NPCs").gameObject;

            if (inactiveNPCCanvas != null){
                blackSmith.transform.SetParent(inactiveNPCCanvas.transform);
                blackSmith.transform.localPosition = new Vector3(0, 0, 0);
            }
            else{
                blackSmith.transform.localPosition = new Vector3(-100, -100, -100);
            }
        }
    }

    public void setMultifightArrangerActive(bool isActive){
        GameObject multiFightArranger = findNPCInScene("NPCMultifightArranger");
        multiFightArranger.GetComponent<NPCMultifightArrangerController>().npcActive = isActive;

        if (isActive == true){
            multiFightArranger.transform.SetParent(GameObject.Find("NPC's Controller").transform);
        }
        else{
            GameObject inactiveNPCCanvas = GameObject.Find("Inactive NPCs").gameObject;

            if (inactiveNPCCanvas != null){
                multiFightArranger.transform.SetParent(inactiveNPCCanvas.transform);
                multiFightArranger.transform.localPosition = new Vector3(0, 0, 0);
            }
            else{
                multiFightArranger.transform.localPosition = new Vector3(-100, -100, -100);
            }
        }
    }

    public GameObject findNPCInScene(string npcName){
        GameObject npc = GameObject.Find(npcName);

        return npc;
    }
}
