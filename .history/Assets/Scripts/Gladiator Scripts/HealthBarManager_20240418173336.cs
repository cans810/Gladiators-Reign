using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public Attributes attributes;
    public GameObject healthBarObject;
    public SpriteRenderer healthBarImage;
    private float maxHealthWidth;
    private float initialHealthWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Get the initial width of the health bar
        maxHealthWidth = healthBarImage.size.x;
        initialHealthWidth = healthBarImage.size.x;
        healthBarObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (attributes.gotHit)
        {
            healthBarObject.SetActive(true);
            
            // Calculate the fill amount based on the current health
            float fillAmount = attributes.HP / attributes.max_HP;
            
            // Update the size of the health bar image
            healthBarImage.size = new Vector2(initialHealthWidth * fillAmount, healthBarImage.size.y);
        }
    }
}
