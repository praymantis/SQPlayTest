using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct AdditionalTransitions
{
    public Graphic target;
    public Color32 normalColor;
    public Color32 selectedColor;
    public Color32 pressedColor;
    public Color32 disabledColor;
}

public class ButtonExtended : Button
{
    public List<AdditionalTransitions> transitions;
}
