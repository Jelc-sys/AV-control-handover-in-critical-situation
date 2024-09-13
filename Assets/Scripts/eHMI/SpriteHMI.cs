using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Sprite av;
    [SerializeField]
    Sprite av2;
    [SerializeField]
	Sprite disabled;

	public override void Display(HMIState state)
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Assets/sounds/automobile-horn-153260.wav");
        base.Display(state);
        Sprite spr = null;
        spr = av;
        switch (state)
        {
            case HMIState.STOP:
                spr = stop;
                break;
            case HMIState.WALK:
                spr = walk;
                break;
            case HMIState.AV:
                spr = av2;
                break;
            case HMIState.HORN:
                player.Play();
                break;
            case HMIState.CB_MODE:

                break;
            default:
                spr = disabled;
                break;
        }
        _renderer.sprite = spr;
    }
}

