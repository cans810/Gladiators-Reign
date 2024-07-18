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
    }

    void Update()
    {
        // Update line positions if skills or this object moves
        UpdateLinePositions();
    }

    public void onMouseHover(){
        generatedPopupInfo = Instantiate(popupInfoPrefab, skillTreeCanvas.transform);
        generatedPopupInfo.GetComponent<TextMeshProUGUI>().text = skillDescription;
    }

    public void onMouseHoverExit(){
        Destroy(generatedPopupInfo);
        generatedPopupInfo = null;
    }

    void AdjustBoxCollider()
    {
        Image image = GetComponent<Image>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

        if (image != null && boxCollider != null)
        {
            // Get the local bounds of the image
            Vector2 spriteSize = image.sprite.bounds.size;
            Vector2 localScale = transform.localScale;

            // Calculate the size of the image in local space
            Vector2 imageSize = new Vector2(
                spriteSize.x * localScale.x,
                spriteSize.y * localScale.y
            );

            // Set the box collider size to match the image size
            boxCollider.size = imageSize;

            // Center the box collider
            boxCollider.offset = Vector2.zero;
        }
        else
        {
            Debug.LogWarning("Image or BoxCollider2D component missing on " + gameObject.name);
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