using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    public string skillName;

    public string skillDescription;
    public string skillEffects;
    public string skillCooldown;

    public List<GameObject> outgoingSkills;
    private List<LineRenderer> lineRenderers;

    public GameObject skillTreeCanvas;
    public GameObject popupInfoPrefab;

    private GameObject generatedPopupInfo;

    void Start()
    {
        skillName = gameObject.name;

        lineRenderers = new List<LineRenderer>();
        DrawLinesToOutgoingSkills();

        AdjustBoxCollider();
    }

    void Update()
    {
        // Update line positions if skills or this object moves
        UpdateLinePositions();
    }

    public void onMouseHover(){
        skillTreeCanvas.transform.Find("PopUpPos").gameObject.transform.position

        generatedPopupInfo = Instantiate(popupInfoPrefab, skillTreeCanvas.transform);
        generatedPopupInfo.GetComponent<TextMeshProUGUI>().text = skillDescription;
    }

    public void onMouseHoverExit(){
        Destroy(generatedPopupInfo);
        generatedPopupInfo = null;
    }

    void AdjustBoxCollider()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if (rectTransform != null && boxCollider != null)
        {
            // Get the size of the RectTransform
            Vector2 size = rectTransform.rect.size;

            // Scale the size by the localScale of the RectTransform
            size.x *= rectTransform.localScale.x;
            size.y *= rectTransform.localScale.y;

            // Set the box collider size to match the RectTransform size
            boxCollider.size = size;

            // Center the box collider
            boxCollider.offset = Vector2.zero;

            // Ensure the BoxCollider2D is enabled
            boxCollider.enabled = true;
        }
        else
        {
            Debug.LogWarning("RectTransform or BoxCollider2D component missing on " + gameObject.name);
        }
    }

    void DrawLinesToOutgoingSkills()
    {
        foreach (GameObject skill in outgoingSkills)
        {
            if (skill != null)
            {
                // Create a new GameObject for the line
                GameObject lineObj = new GameObject("Line to " + skill.name);
                lineObj.transform.SetParent(transform);

                // Add a LineRenderer component
                LineRenderer line = lineObj.AddComponent<LineRenderer>();

                // Configure the LineRenderer
                line.startWidth = 0.1f;
                line.endWidth = 0.1f;
                line.positionCount = 2;
                line.useWorldSpace = true;

                // Set the line color (you can adjust this as needed)
                line.startColor = Color.white;
                line.endColor = Color.white;

                // Set the line material (you may want to create a specific material for this)
                line.material = new Material(Shader.Find("Sprites/Default"));

                // Add to our list of line renderers
                lineRenderers.Add(line);
            }
        }

        // Initial position update
        UpdateLinePositions();
    }

    void UpdateLinePositions()
    {
        for (int i = 0; i < outgoingSkills.Count; i++)
        {
            if (outgoingSkills[i] != null && i < lineRenderers.Count)
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = outgoingSkills[i].transform.position;

                lineRenderers[i].SetPosition(0, startPosition);
                lineRenderers[i].SetPosition(1, endPosition);
            }
        }
    }
}