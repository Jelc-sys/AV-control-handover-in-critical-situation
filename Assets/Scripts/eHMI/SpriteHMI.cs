using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Threading;

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

    public string postProcessObjectName = "PostProcess";
    public PostProcessVolume postProcessVolume; // To store the Post-process Volume component
    private bool isPostProcessEnabled = false;

    public override void Display(HMIState state)
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Assets/sounds/automobile-horn-153260.wav");
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
                //isPostProcessEnabled = !isPostProcessEnabled;
                //postProcessVolume.enabled = isPostProcessEnabled;
                StartCoroutine(FlashCoroutine());
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

