using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;
using UnityEngine.Rendering.PostProcessing;

public class Music : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _renderer;
    public GameObject dashWarning;
    public GameObject reactionTimeTracker;
    private SwitchFromAItoMDV switchToMDVScript;
    public GameObject carAI;
    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"Assets/Sounds/Voice1.wav");
    //public GameObject AICarObj;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void playMusic()
    {
        
        carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
        dashWarning = GameObject.Find("Dash_Warning"); //Assigning Dash_Warning object with the code
        reactionTimeTracker = GameObject.Find("ReactionTimeTracker");
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        player.Play();
        yield return new WaitForSeconds(100.0f);
    }
}
