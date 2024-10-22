using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private GameObject HMIStatic;
    private Transform dashWarning;
    private Transform onScreenTakeOver;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered script vibration 1");
        HMIStatic = GameObject.Find("StaticHMI_dash(Clone)");
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = carAI.transform.Find("Dash_Warning");
        onScreenTakeOver = carAI.transform.Find("OnScreen_TakeOver");
        SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRenderer2 = onScreenTakeOver.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        spriteRenderer2.enabled = true;
        ControllerVibration controllerScript = GetComponent<ControllerVibration>();
        controllerScript.TriggerVibration();
        Debug.Log("entered script vibration 2");
        //SpeedSettings.speed = 0;

        //SpriteHMI_DASH HMIScript = HMIStatic.GetComponent<SpriteHMI_DASH>();
        //HMIScript.Display(HMIState.DASH);
    }
}