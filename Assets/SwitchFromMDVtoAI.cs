using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;

public class SwitchFromMDVtoAI : MonoBehaviour
{ 
    public GameObject SwitchCar;

    private AICar aiCarScript;
    private WheelVehicle wheelVehicleScript;
    // Start is called before the first frame update
    void Start()
    {
        aiCarScript = GetComponent<AICar>();
        wheelVehicleScript = GetComponent<WheelVehicle>();
        Debug.Log(aiCarScript.enabled);
        Debug.Log(wheelVehicleScript.enabled);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void makeSwitch()
    {
        SwitchCar = GameObject.Find("DrivableSmartCommon-no_driver(Clone)"); //IMPORTANT TO SEARCH LIKE THIS OR YOU WILL EDIT THE PREFAB NOT INSTANCE IN GAME
        aiCarScript = SwitchCar.GetComponent<AICar>();
        wheelVehicleScript = SwitchCar.GetComponent<WheelVehicle>();
        aiCarScript.enabled = true;        // Enable AI control
        wheelVehicleScript.enabled = false;  // Disable manual control
        Debug.Log(aiCarScript.enabled);
        Debug.Log(wheelVehicleScript.enabled);
        Debug.Log("Switched to AI Control (AICar)");
    }
}
