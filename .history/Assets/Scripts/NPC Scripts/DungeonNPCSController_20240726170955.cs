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
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Register event
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; // Unregister event
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("DungeonScene"))
        {
            bool isEvenDay = GameManager.Instance.currentDay % 2 == 0;
            SetNPCActive("NPCBlacksmith", isEvenDay);
            SetNPCActive("NPCMultifightArranger", !isEvenDay);
        }
        else
        {
            HandleNPCOutsideDungeon("NPCBlacksmith");
            HandleNPCOutsideDungeon("NPCMultifightArranger");
        }
    }

    private void SetNPCActive(string npcName, bool isActive)
    {
        GameObject npc = FindNPCInScene(npcName);
        if (npc != null)
        {
            npc.GetComponent<NPCControllerBase>().npcActive = isActive; // Assuming all NPC controllers inherit from NPCControllerBase

            if (isActive)
            {
                SetParent(npc, GameObject.Find("NPC's Controller"));
            }
            else
            {
                GameObject inactiveNPCCanvas = GameObject.Find("Inactive NPCs");
                SetParent(npc, inactiveNPCCanvas ?? null);
                if (inactiveNPCCanvas == null)
                {
                    npc.transform.localPosition = new Vector3(-100, -100, -100);
                }
            }
        }
        else
        {
            Debug.LogWarning($"{npcName} not found");
        }
    }

    private void HandleNPCOutsideDungeon(string npcName)
    {
        GameObject npc = FindNPCInScene(npcName);
        if (npc != null)
        {
            npc.GetComponent<NPCControllerBase>().npcActive = false;
            SetParent(npc, null);
            npc.transform.position = new Vector3(-100, -100, -100);
        }
        else
        {
            Debug.LogWarning($"{npcName} not found");
        }
    }

    private void SetParent(GameObject child, GameObject newParent)
    {
        if (newParent != null)
        {
            child.transform.SetParent(newParent.transform);
            child.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            child.transform.SetParent(null);
        }
    }

    private GameObject FindNPCInScene(string npcName)
    {
        return GameObject.Find(npcName);
    }
}
