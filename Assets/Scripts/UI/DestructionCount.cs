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

        slider.value = currentHealth / totalHealth;
        uiText.text = (currentHealth / totalHealth * 100).ToString() + "%";
    }


}
