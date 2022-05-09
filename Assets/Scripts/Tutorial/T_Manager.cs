using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Manager : MonoBehaviour
{
    public GameObject[] popUps;
    int popUpsIndex;
    // public GameObject spawner;
    T_InstanciateTower t_InstanciateTower;
    T_Owls t_Owls;

    void Start()
    {
        popUpsIndex = 0;
        t_InstanciateTower = FindObjectOfType<T_InstanciateTower>();
        t_Owls = FindObjectOfType<T_Owls>();
    }

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpsIndex)
            {
                popUps[i].SetActive(true); 
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpsIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                popUpsIndex++;
            }
        }

        else if (popUpsIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                popUpsIndex++;
            }
        }

        else if(popUpsIndex == 2)
        {
            t_InstanciateTower.T_Building();

            if (t_InstanciateTower.isTowerAlive == false)
            {
                popUpsIndex++;
            }
        }

        else if (popUpsIndex == 3)
        {
            t_Owls.T_OwlSpawn();

            if (t_Owls.isOwlAlive == false)
            {
                popUpsIndex++;
            }
        }

        else if (popUpsIndex == 4)
        {
            if (true)
            {
                popUpsIndex++;
            }
        }






    }
}
