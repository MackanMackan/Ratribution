using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowPaw : MonoBehaviour, ISelectHandler
{
    bool selected = false;
    //Transform child;
    private void Start()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData eventData)
    {
        
        transform.GetChild(1).gameObject.SetActive(true);
     
    }

    private void Update()
    {

    }
}
   




