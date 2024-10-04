using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Threading;
//using UnityEditor.SceneManagement;

//simple sprite swapping implementation of HMI base class
public class SpriteHMI : HMI
{
    [SerializeField]
    SpriteRenderer _renderer;
    [SerializeField]
    Sprite stop;
	[SerializeField]
	Sprite walk;
    [SerializeField]
	Sprite disabled;

    [SerializeField]
    public GameObject dashWarning; //Added to find the dash warning sprite added to the drivable Smart Car
    public GameObject reactionTimeTracker; //added to track reaction time on key press
    public PostProcessVolume postProcessVolume; // To store the Post-process Volume component
    private bool isPostProcessEnabled = false;
    public GameObject carAI;      //To switch to MDV
    private SwitchFromAItoMDV switchToMDVScript;
    private SwitchFromMDVtoAI switchToAIScript;

    public override void Display(HMIState state)
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Assets/sounds/automobile-horn-153260.wav");
        dashWarning = GameObject.Find("Dash_Warning"); //Assigning Dash_Warning object with the code
        reactionTimeTracker = GameObject.Find("ReactionTimeTracker");
        SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>(); //Finds SpriteRenderer in the Dash_Warning
        ReactionTimeTracker reactionScript = reactionTimeTracker.GetComponent<ReactionTimeTracker>();
        base.Display(state);
        Sprite spr = null;
        GameObject postProcessObject = GameObject.Find("PostProcess");
        postProcessVolume = postProcessObject.GetComponent<PostProcessVolume>();

        switch (state)
        {
            case HMIState.STOP:
                spr = stop;
                break;
            case HMIState.WALK:
                spr = walk;
                break;
            case HMIState.HORN:
                player.Play();
                break;
            case HMIState.CB_MODE:
                StartCoroutine(FlashCoroutine());
                spriteRenderer.enabled = !spriteRenderer.enabled; //Enables or disables warning lamp
                reactionScript.StartTimer("Strobe flash");
                break;
            case HMIState.MDV:
                switchToMDVScript = carAI.GetComponent<SwitchFromAItoMDV>();
                switchToMDVScript.makeSwitch();
                break;
            case HMIState.AI:
                switchToAIScript = carAI.GetComponent<SwitchFromMDVtoAI>();
                switchToAIScript.makeSwitch();
                break;
            default:
                spr = disabled;
                break;
        }
        _renderer.sprite = spr;
    }

    IEnumerator FlashCoroutine()
    {
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;
        yield return new WaitForSeconds(0.1f);
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;
        yield return new WaitForSeconds(0.1f);
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;
        yield return new WaitForSeconds(0.1f);
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;

    }
}

