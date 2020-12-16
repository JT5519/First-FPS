using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderDisp : MonoBehaviour
{
    private Text myText;
    private void Awake()
    {
        myText = GetComponent<Text>();
    }
    public void displayAsPercent(float x)
    {
        myText.text = Mathf.RoundToInt(x / 2 * 100).ToString() + "%";
    }
    
}
