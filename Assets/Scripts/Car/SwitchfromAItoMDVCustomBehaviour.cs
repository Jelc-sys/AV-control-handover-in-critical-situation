using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchFromAItoMDVCustomBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private SwitchFromAItoMDV switchToMDVScript;
    private void OnTriggerEnter(Collider other)
    {
        switchToMDVScript = carAI.GetComponent<SwitchFromAItoMDV>();
        switchToMDVScript.makeSwitch();
    }
}