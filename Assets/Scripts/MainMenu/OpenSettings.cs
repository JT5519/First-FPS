using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to handle settings menu. 
public class OpenSettings : MonoBehaviour
{
    public GameObject settingsCanvas;//settings canvas
    public GameObject myCanvas;//main canvas
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
