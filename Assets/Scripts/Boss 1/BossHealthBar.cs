using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color red;


    public void SetHealth(float health, float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
        
        slider.fillRect.GetComponentInChildren<Image>().color = red;
        print("Health Bar Updated");
        print("Health: " + health);
        print("Max Health: " + maxHealth);
    }

    // Start is called before the first frame update
    void Start()
    {
       slider.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
