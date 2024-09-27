using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using VehicleBehaviour;

public class SwitchToMDV : MonoBehaviour
{
    //BAD SCRIPT NOT BEING USED
    public GameObject SwitchCar;

    public AICar aiCarScript;
    public WheelVehicle wheelVehicleScript;
    //public WaypointProgressTracker tracker;

    // Start is called before the first frame update
    void Start()
    {
        aiCarScript = SwitchCar.GetComponent<AICar>();
        wheelVehicleScript = SwitchCar.GetComponent<WheelVehicle>();

        aiCarScript.enabled = false;        // Disable AI control
        //tracker.enabled = false;            //Disable the tracker
        wheelVehicleScript.enabled = true;  // Enable manual control
        Debug.Log("Switched to Manual Control (WheelVehicle)");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
