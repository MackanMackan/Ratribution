using System;
using UnityEngine;

// Generate a screenshot and save to disk with the name SomeLevel.png.
public class Screenshot : MonoBehaviour
{
    public int multiplier = 4;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string name = Application.productName + date + ".png";
            ScreenCapture.CaptureScreenshot(name, multiplier);
            Debug.Log("Screenshot saved to: " + name);
        }
    }
}