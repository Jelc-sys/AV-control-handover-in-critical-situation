using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOverNowBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private Transform dashWarning;
    private Transform onScreenTakeOver;
    private Transform onScreenTakeOverNow;

    private void OnTriggerEnter(Collider other)
    {
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = carAI.transform.Find("Dash_Warning");
        onScreenTakeOver = carAI.transform.Find("OnScreen_TakeOver");
        onScreenTakeOverNow = carAI.transform.Find("OnScreen_TakeOverNow");
        SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = onScreenTakeOver.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer3 = onScreenTakeOverNow.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        spriteRenderer2.enabled = false;
        spriteRenderer3.enabled = true;
        //SpeedSettings.speed = 0;
    }
}