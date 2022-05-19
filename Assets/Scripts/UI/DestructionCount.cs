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

    public void SetStartTotalHealth(float startValue)
    {
        totalHealth = startValue;
        currentHealth = startValue;
    }
    public void SetCurrentHealth(float value)
    {
        currentHealth = value;
    }
    private void Update()
    {
        UpdateUISlider();
    }

    private void UpdateUISlider()
    {
        float total1 = currentHealth / totalHealth * 100;
        int total= Mathf.RoundToInt(total1);

        slider.value = currentHealth / totalHealth;
        slider.value = total;
        //uiText.text = total.ToString() + "%";
    }
}
