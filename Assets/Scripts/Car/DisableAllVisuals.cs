using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAllVisuals : MonoBehaviour
{
    public GameObject carAI;
    private Transform dashWarning;
    private Transform onScreenWarning;
    private Transform onScreenTakeOver;
    private Transform onScreenTakeOverNow;
    private Transform v2x;
    private GameObject HMIStatic;

    private void OnTriggerEnter(Collider other)
    {
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = carAI.transform.Find("Dash_Warning");
        onScreenWarning = carAI.transform.Find("OnScreen_Warning");
        onScreenTakeOver = carAI.transform.Find("OnScreen_TakeOver");
        onScreenTakeOverNow = carAI.transform.Find("OnScreen_TakeOverNow");
        v2x = carAI.transform.Find("OnScreen_V2V");
        SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = onScreenWarning.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer3 = onScreenTakeOver.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer4 = onScreenTakeOverNow.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer5 = v2x.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        spriteRenderer2.enabled = false;
        spriteRenderer3.enabled = false;
        spriteRenderer4.enabled = false;
        spriteRenderer5.enabled = false;
        HMIStatic = GameObject.Find("StaticHMI_dash(Clone)");
        SpriteHMI_DASH HMIScript = HMIStatic.GetComponent<SpriteHMI_DASH>();
        HMIScript.Display(HMIState.DISABLED);

        //SpeedSettings.speed = 0;
    }
}