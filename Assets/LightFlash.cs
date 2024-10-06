using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;
using UnityEngine.Rendering.PostProcessing;

public class LightFlash : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _renderer;
    public GameObject dashWarning;
    public GameObject reactionTimeTracker;
    public PostProcessVolume postProcessVolume; // To store the Post-process Volume component
    private bool isPostProcessEnabled = false;
    private SwitchFromAItoMDV switchToMDVScript;
    public GameObject carAI;

    //public GameObject AICarObj;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void flash()
    {
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = GameObject.Find("Dash_Warning"); //Assigning Dash_Warning object with the code
        
        GameObject postProcessObject = GameObject.Find("PostProcess");
        postProcessVolume = postProcessObject.GetComponent<PostProcessVolume>();
        SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>(); //Finds SpriteRenderer in the Dash_Warning
        //ControllerVibration controllerScript = GetComponent<ControllerVibration>();
        //ReactionTimeTracker reactionScript = reactionTimeTracker.GetComponent<ReactionTimeTracker>();
        //controllerScript.TriggerVibration();
        StartCoroutine(FlashCoroutine());
        //spriteRenderer.enabled = !spriteRenderer.enabled; //Enables or disables warning lamp
        //switchToMDVScript = carAI.GetComponent<SwitchFromAItoMDV>();
        //switchToMDVScript.makeSwitch();
    }

    IEnumerator FlashCoroutine()
    {
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;
        yield return new WaitForSeconds(0.1f);
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;
        yield return new WaitForSeconds(0.1f);
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;
        yield return new WaitForSeconds(0.1f);
        isPostProcessEnabled = !isPostProcessEnabled;
        postProcessVolume.enabled = isPostProcessEnabled;
        //reactionTimeTracker = GameObject.Find("ReactionTimeTracker");
        //reactionScript.StartTimer("Strobe flash");
    }
}
