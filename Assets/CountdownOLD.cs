using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;
using UnityEngine.Rendering.PostProcessing;

public class CountdownOLD : MonoBehaviour
{
    public GameObject HMIStatic;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void startCountdown()
    {
        SpriteHMI_DASH HMIScript = HMIStatic.GetComponent<SpriteHMI_DASH>();
        HMIScript.Display(HMIState.DASH);
    }

}
