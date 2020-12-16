using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject myCanvas;
    public void openSettings()
    {
        myCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }
    public void closeSettings()
    {
        settingsCanvas.SetActive(false);
        myCanvas.SetActive(true);
    }
}
