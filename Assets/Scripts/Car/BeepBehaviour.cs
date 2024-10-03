using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private Beep BeepScript;
    private GameObject HMIStatic;
    private void OnTriggerEnter(Collider other)
    {
        HMIStatic = GameObject.Find("StaticHMI_dash(Clone)");
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        //SpeedSettings.speed = 0;
        BeepScript = carAI.GetComponent<Beep>();
        BeepScript.playBeep();
        SpriteHMI_DASH HMIScript = HMIStatic.GetComponent<SpriteHMI_DASH>();
        HMIScript.Display(HMIState.DASH);
    }
}