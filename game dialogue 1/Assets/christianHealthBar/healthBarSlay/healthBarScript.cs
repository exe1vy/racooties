using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{

    public Slider healthSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStartHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void setHealth(int health)
    {
        healthSlider.value = health;
    }

}
