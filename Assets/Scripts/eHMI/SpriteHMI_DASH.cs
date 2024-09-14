using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Threading;

//simple sprite swapping implementation of HMI base class
public class SpriteHMI_DASH : HMI
{
    [SerializeField]
    public SpriteRenderer _renderer_Dash;
    [SerializeField]
    Sprite dash;
    [SerializeField]
	Sprite disabled;

    public override void Display(HMIState state)
    {
        base.Display(state);

        if (_renderer_Dash == null)
        {
            Debug.LogError("_renderer_Dash is null!");
        }

        Sprite spr = null;
        switch (state)
        {
            case HMIState.DASH:
                spr = dash;
                break;
            default:
                spr = disabled;
                break;
        }
        _renderer_Dash.sprite = spr;

    }
}

