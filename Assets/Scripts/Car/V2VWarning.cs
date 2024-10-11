using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2VWarning : MonoBehaviour
{
    public GameObject carAI;
    private Transform onScreenWarning;
    private void OnTriggerEnter(Collider other)
    {
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        onScreenWarning = carAI.transform.Find("OnScreen_V2V");
        SpriteRenderer spriteRenderer = onScreenWarning.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }
}