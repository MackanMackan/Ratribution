using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShowPaw : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private void Start()
    {
        transform.GetChild(1).gameObject.SetActive(false);

        if (transform.parent.GetChild(0) == transform)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        
        transform.GetChild(1).gameObject.SetActive(true);
        ServiceLocator.Instance.GetAudioProvider().PlayOneShot("menu",transform.position,false);

    }
    public void OnDeselect(BaseEventData data)
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

}
   




