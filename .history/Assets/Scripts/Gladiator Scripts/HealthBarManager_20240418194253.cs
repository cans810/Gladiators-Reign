using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public Attributes attributes;
    public GameObject healthBarObject;
    public SpriteRenderer healthBarImage;
    public SpriteRenderer healthbarBG;
    private float maxHealthWidth;
    private float initialHealthWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Get the initial width of the health bar
        maxHealthWidth = healthBarImage.size.x;
        initialHealthWidth = healthBarImage.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (attributes.gotHit)
        {
            healthBarImage.gameObject.SetActive(true);
            healthbarBG.gameObject.SetActive(true);
            
            // Calculate the fill amount based on the current health
            float fillAmount = attributes.HP / attributes.max_HP;
            
            // Update the size of the health bar image
            healthBarImage.transform.localScale = new Vector2(initialHealthWidth * fillAmount, healthBarImage.size.y);
        }
        else{
            healthBarImage.gameObject.SetActive(false);
            healthbarBG.gameObject.SetActive(false);
        }
    }
}
