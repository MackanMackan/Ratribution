using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterUI : MonoBehaviour
{
    Slider slider;
    CharacterHealth charHp;
    private void Start()
    {
        StartCoroutine(GetPlayerRef());
    }
    IEnumerator GetPlayerRef()
    {
        yield return new WaitForSeconds(1f);
        charHp = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
        slider = GetComponent<Slider>();
        slider.maxValue = charHp.GetHealth();
        slider.value = charHp.GetHealth();
        charHp.onHitPlayer += UpdateUISlider;
    }
    public void UpdateUISlider()
    {
        slider.value = charHp.GetHealth();       
    }
}
