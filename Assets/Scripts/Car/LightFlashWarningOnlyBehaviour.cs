using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlashWarningOnlyBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private GameObject HMIStatic;
    private LightFlash LightFlashScript;
    private Transform dashWarning;
    private Transform onScreenWarning;
    private void OnTriggerEnter(Collider other)
    {
        HMIStatic = GameObject.Find("StaticHMI_dash(Clone)");
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = carAI.transform.Find("Dash_Warning");
        onScreenWarning = carAI.transform.Find("OnScreen_Warning");
        SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = onScreenWarning.GetComponent<SpriteRenderer>();

        //SpeedSettings.speed = 0;
        LightFlashScript = carAI.GetComponent<LightFlash>();
        LightFlashScript.flash();
        spriteRenderer.enabled = true;
        spriteRenderer2.enabled = true;

        //SpriteHMI_DASH HMIScript = HMIStatic.GetComponent<SpriteHMI_DASH>();
        //HMIScript.Display(HMIState.DASH);
    }
}