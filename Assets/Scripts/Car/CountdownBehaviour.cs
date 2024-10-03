using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBehaviour : MonoBehaviour
{
    public GameObject carAI;
    private Countdown CountdownScript;
    private void OnTriggerEnter(Collider other)
    {
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        //SpeedSettings.speed = 0;
        CountdownScript = carAI.GetComponent<Countdown>();
        CountdownScript.startCountdown();
    }
}