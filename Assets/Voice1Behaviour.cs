using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice1Behaviour : MonoBehaviour
{
    public GameObject carAI;
    private Voice1 MusicScript;
    private GameObject HMIStatic;
    private Transform dashWarning;
    private Transform onScreenTakeOver;
    private void OnTriggerEnter(Collider other)
    {
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        MusicScript = carAI.GetComponent<Voice1>();
        MusicScript.playVoice1();
    }
}