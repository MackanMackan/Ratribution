using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    Slider slider;
    float currentHealth;
    //GameObject refPlayer;
    public CharacterHealth characterHealth;

    private void Start()

    {
        //refPlayer = GameObject.FindGameObjectWithTag("Player");
       // characterHealth = refPlayer.GetComponent<CharacterHealth>();
        slider = GetComponent<Slider>();
        currentHealth = characterHealth.GetHealth();
    }

    private void Update()
    {
        //Code for test
        if (Input.GetMouseButtonDown(1))
        {
            currentHealth--;            
            UpdateUISlider(10); //move to place where you take damage.
        }
    }

    public void UpdateUISlider(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;       
    }
}
