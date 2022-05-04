using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    Slider slider;
    float currentHealth;
    public CharacterHealth characterHealth;

    private void Start()

    {
        slider = GetComponent<Slider>();
        currentHealth = characterHealth.GetHealth();
    }

    private void Update()
    {
       
            //currentHealth--;            
            //UpdateUISlider(10); //move to place where you take damage.
        
    }

    public void UpdateUISlider(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;       
    }
}
