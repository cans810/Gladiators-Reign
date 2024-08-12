using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonNPCSController : MonoBehaviour
{
    public static DungeonNPCSController Instance;
    public Canvas canvas;

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

        canvas = GetComponent<Canvas>();
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
        canvas.worldCamera = Camera.main;
        if (scene.name.Equals("DungeonScene"))
        {
            bool isEvenDay = GameManager.Instance.currentDay % 2 == 0;
            SetNPCActive("NPCBlacksmith", !isEvenDay);
            MultiFightArranger_Condition();
        }
        else
        {
            HandleNPCOutsideDungeon("NPCBlacksmith");
            HandleNPCOutsideDungeon("NPCMultifightArranger");
        }
    }

    public void MultiFightArranger_Condition(){
        bool isEvenDay = GameManager.Instance.currentDay % 2 == 0;

        if (isEvenDay && GameManager.Instance.playerGLs.Count >= 2){
            SetNPCActive("NPCBlacksmith",true);
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
                npc.transform.position = new Vector3(npc.transform.position.x, npc.transform.position.y, 0);
                npc.transform.localScale = new Vector3(0.864f,0.864f,0.864f);

                SetComponentsActive(npc,true);
            }
            else
            {
                GameObject inactiveNPCCanvas = GameObject.Find("Inactive NPCs");
                SetParent(npc, inactiveNPCCanvas ?? null);
                inactiveNPCCanvas.transform.localPosition = new Vector3(-1000, -1000, -100);
                npc.transform.localPosition = new Vector3(-1000, -1000, -100);
                
            }
        }
        else
        {
            Debug.LogWarning($"{npcName} not found");
        }
    }

    public void SetComponentsActive(GameObject obj, bool isActive)
    {
        Component[] components = obj.GetComponents<Component>();

        foreach (Component component in components)
        {
            Type type = component.GetType();
            var enabledProperty = type.GetProperty("enabled");

            if (enabledProperty != null)
            {
                enabledProperty.SetValue(component, isActive, null);
            }
        }
    }

    private void HandleNPCOutsideDungeon(string npcName)
    {
        GameObject npc = FindNPCInScene(npcName);
        if (npc != null)
        {
            npc.GetComponent<NPCControllerBase>().npcActive = false;
            SetParent(npc, null);
            npc.transform.position = new Vector3(-1000, -1000, -100);
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
            Vector3 worldPosition = child.transform.position; // Save world position before reparenting
            child.transform.SetParent(newParent.transform);
            child.transform.position = worldPosition; // Set world position back after reparenting
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
