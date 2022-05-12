using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class T_Manager : MonoBehaviour
{
    public GameObject[] popUps;
    int popUpsIndex;
    T_InstanciateTower t_InstanciateTower;
    T_Owls t_Owls;

    private PlayerInputActions playerControls;

    bool jaha;
    float minTime = 5;
    float currentTIme;
    GameObject[] barrels;

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }

    void Start()
    {
        popUpsIndex = 0;
        t_InstanciateTower = FindObjectOfType<T_InstanciateTower>();
        t_Owls = FindObjectOfType<T_Owls>();

        barrels = GameObject.FindGameObjectsWithTag("Pickup");
    }

    public void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
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

        switch(popUpsIndex)
        {
            //MOVE
            case 0: 
                
                currentTIme += Time.deltaTime;

                if (playerControls.Player.Move.triggered && currentTIme > minTime)
                {
                    popUpsIndex++;
                    currentTIme = 0;
                }

                break;

            //JUMP
            case 1:           

                if (playerControls.Player.Jump.triggered)
                {
                    popUpsIndex++;                   
                }

                break;

            //ATTACK
            case 2:

                t_InstanciateTower.T_Building();

                if (playerControls.Player.Fire.triggered || t_InstanciateTower.next == true)
                {
                    popUpsIndex++;
                }

                break;
            //ROLL
            case 3:               

                if (playerControls.Player.Roll.triggered)
                {
                    popUpsIndex++;
                }

                break;

            //EXPLOSIV
            case 4:

                for (int i = 0; i < barrels.Length; i++)
                {                 
                    if (barrels[i] == null)
                     {                       
                         popUpsIndex++;
                     }
                }   
                
                break;
        }
    }
}
