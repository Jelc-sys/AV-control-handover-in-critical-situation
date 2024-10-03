using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;
using UnityEngine.Rendering.PostProcessing;

public class Beep : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _renderer;
    public GameObject dashWarning;
    public GameObject reactionTimeTracker;
    private SwitchFromAItoMDV switchToMDVScript;
    public GameObject carAI;
    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Assets/sounds/beep-01a.wav");

    //public GameObject AICarObj;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playBeep()
    {
        
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = GameObject.Find("Dash_Warning"); //Assigning Dash_Warning object with the code
        reactionTimeTracker = GameObject.Find("ReactionTimeTracker");
        //SpriteRenderer spriteRenderer = dashWarning.GetComponent<SpriteRenderer>(); //Finds SpriteRenderer in the Dash_Warning
        StartCoroutine(FlashCoroutine());
        //spriteRenderer.enabled = true; //Enables warning lamp
    }

    IEnumerator FlashCoroutine()
    {
        player.Play();
        yield return new WaitForSeconds(0.5f);
        player.Play();
        yield return new WaitForSeconds(0.5f);
        player.Play();
        yield return new WaitForSeconds(0.5f);
        player.Play();
        ReactionTimeTracker reactionScript = reactionTimeTracker.GetComponent<ReactionTimeTracker>();
        reactionScript.StartTimer("Auditory beep");
        //switchToMDVScript = carAI.GetComponent<SwitchFromAItoMDV>();
        //switchToMDVScript.makeSwitch();
    }
}
