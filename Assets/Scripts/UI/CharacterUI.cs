using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    Slider slider;

    private void Start()

    {
        slider = GetComponent<Slider>();
        slider.maxValue = CharacterHealth.GetHealth();
        slider.value = CharacterHealth.GetHealth();
        CharacterHealth.onHitPlayer += UpdateUISlider;    
    }

    public void UpdateUISlider()
    {
        slider.value = CharacterHealth.GetHealth();       
    }

    private void Update()
    {
        Debug.Log(CharacterHealth.GetHealth());
    }
}
