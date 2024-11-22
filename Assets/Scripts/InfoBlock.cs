using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoBlock : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI value;
    public Slider slider;

    public void SetInfo(string title, int value, int maxValue)
    {
        this.title.text = title;
        this.value.text = "" + value;
        if (slider != null)
        {
            slider.maxValue = maxValue;
            slider.value = value;
        }
    }

    public void SetInfo(string title, float value, float maxValue)
    {
        this.title.text = title;
        this.value.text = "" + value;
        if (slider != null)
        {
            slider.maxValue = maxValue;
            slider.value = value;
        }
    }

    public void SetInfo(string title, string value)
    {
        this.title.text = title;
        this.value.text = value;
    }
}
