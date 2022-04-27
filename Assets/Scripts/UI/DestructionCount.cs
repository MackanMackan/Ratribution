using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DestructionCount : MonoBehaviour
{
    float totalHealth;
    float currentHealth;
    public TextMeshProUGUI uiText;

    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();       
    }

    public void AddHealth(int value)
    {
        totalHealth += value;
        currentHealth = totalHealth;
    }

    public void UpdateUISlider(int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth / totalHealth;
        uiText.text = (currentHealth / totalHealth * 100).ToString() + "%";
    }


}
