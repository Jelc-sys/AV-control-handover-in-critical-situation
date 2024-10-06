using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private GameObject HMIStatic;
    private Transform dashWarning;
    private void OnTriggerEnter(Collider other)
    {
        HMIStatic = GameObject.Find("StaticHMI_dash(Clone)");
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = carAI.transform.Find("Dash_Warning");
        SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        ControllerVibration controllerScript = GetComponent<ControllerVibration>();
        controllerScript.TriggerVibration();
        //SpeedSettings.speed = 0;

        SpriteHMI_DASH HMIScript = HMIStatic.GetComponent<SpriteHMI_DASH>();
        HMIScript.Display(HMIState.DASH);
    }
}