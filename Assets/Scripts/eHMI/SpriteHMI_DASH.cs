using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Threading;
using System.Threading.Tasks;

//simple sprite swapping implementation of HMI base class
public class SpriteHMI_DASH : HMI
{
    [SerializeField]
    public SpriteRenderer _renderer_Dash;
    [SerializeField]
    Sprite disp5;
    [SerializeField]
    Sprite disp4;
    [SerializeField]
    Sprite disp3;
    [SerializeField]
    Sprite disp2;
    [SerializeField]
    Sprite disp1;
    [SerializeField]
    Sprite dash;
    [SerializeField]
	Sprite disabled;

    public GameObject reactionTimeTracker;
    public GameObject carAI;      //To switch to MDV
    private SwitchFromAItoMDV switchToMDVScript;

    public override async void Display(HMIState state)
    {
        base.Display(state);
        reactionTimeTracker = GameObject.Find("ReactionTimeTracker");
        ReactionTimeTracker reactionScript = reactionTimeTracker.GetComponent<ReactionTimeTracker>();

        if (_renderer_Dash == null)
        {
            Debug.LogError("_renderer_Dash is null!");
        }

        Sprite spr = null;
        switch (state)
        {
            case HMIState.DASH:
                //startTime = Time.time;
                spr = disp5;
                _renderer_Dash.sprite = spr;
                //reactionScript.StartTimer("Dash countdown");
                await WaitForSecondsAsync(1f);
                spr = disp4;
                _renderer_Dash.sprite = spr;
                await WaitForSecondsAsync(2f);
                spr = disp3;
                _renderer_Dash.sprite = spr;
                await WaitForSecondsAsync(2f);
                spr = disp2;
                _renderer_Dash.sprite = spr;
                await WaitForSecondsAsync(2f);
                spr = disp1;
                _renderer_Dash.sprite = spr;
                await WaitForSecondsAsync(2f);
                spr = dash;
                switchToMDVScript = carAI.GetComponent<SwitchFromAItoMDV>();
                switchToMDVScript.makeSwitch();
                reactionScript.StartTimer("Dashboard countdown");
                break;
            default:
                spr = disabled;
                break;
        }
        _renderer_Dash.sprite = spr;

    }
    private async Task WaitForSecondsAsync(float seconds)
    {
        await Task.Delay((int)(seconds * 1000)); // Convert seconds to milliseconds
    }
}

