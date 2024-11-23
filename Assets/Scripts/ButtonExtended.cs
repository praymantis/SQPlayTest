using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct AdditionalTransition
{
    public Graphic target;
    public ColorBlock colors;
}

public class ButtonExtended : Button
{
    public List<AdditionalTransition> additionalTransitions;

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);

        switch (state)
        {
            case SelectionState.Normal:
                for (int i = 0; i < additionalTransitions.Count; i++)
                    if (additionalTransitions[i].target != null)
                        additionalTransitions[i].target.color = additionalTransitions[i].colors.normalColor;
                break;
            case SelectionState.Highlighted:
                for (int i = 0; i < additionalTransitions.Count; i++)
                    if (additionalTransitions[i].target != null)
                        additionalTransitions[i].target.color = additionalTransitions[i].colors.highlightedColor;
                break;
            case SelectionState.Pressed:
                for (int i = 0; i < additionalTransitions.Count; i++)
                    if (additionalTransitions[i].target != null)
                        additionalTransitions[i].target.color = additionalTransitions[i].colors.pressedColor;
                break;
            case SelectionState.Selected:
                for (int i = 0; i < additionalTransitions.Count; i++)
                    if (additionalTransitions[i].target != null)
                        additionalTransitions[i].target.color = additionalTransitions[i].colors.selectedColor;
                break;
            case SelectionState.Disabled:
                for (int i = 0; i < additionalTransitions.Count; i++)
                    if (additionalTransitions[i].target != null)
                        additionalTransitions[i].target.color = additionalTransitions[i].colors.disabledColor;
                break;
        }
    }
}
