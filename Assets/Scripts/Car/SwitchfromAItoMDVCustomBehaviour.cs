using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFromAItoMDVCustomBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private SwitchFromAItoMDV switchToMDVScript;
    private void OnTriggerEnter(Collider other)
    {
        //SpeedSettings.speed = 0;
        switchToMDVScript = carAI.GetComponent<SwitchFromAItoMDV>();
        switchToMDVScript.makeSwitch();
    }
}