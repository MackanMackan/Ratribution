using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    [SerializeField] Image loadImg;
    public void GotToMainMenu()
    {
        loadImg.enabled = true;
        SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        loadImg.enabled = true;
        SceneManager.LoadScene("MainGame");
    }
}
