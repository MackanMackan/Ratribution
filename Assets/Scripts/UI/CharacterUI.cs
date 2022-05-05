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

    private void Update()
    {
       
            //currentHealth--;            
            //UpdateUISlider(10); //move to place where you take damage.
        
    }

    public void UpdateUISlider()
    {
        slider.value = CharacterHealth.GetHealth();       
    }
}
