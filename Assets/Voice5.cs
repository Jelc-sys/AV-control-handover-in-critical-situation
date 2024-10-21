using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;
using UnityEngine.Rendering.PostProcessing;

public class Voice5 : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _renderer;
    
    public GameObject dashWarning;
    public GameObject reactionTimeTracker;
    public GameObject carAI;
    private SwitchFromAItoMDV switchToMDVScript;

    // Reference to AudioSource component for playing the audio clip
    public AudioClip voiceClip;  // Assign your audio clip in the Unity inspector
    private AudioSource audioSource;

    private bool hasPlayed = false; // To track if the sound has been played

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = voiceClip;
        audioSource.loop = false;  // Ensure it does not loop
    }

    // Update is called once per frame
    void Update()
    {
        // You can call playMusic from here or based on some other condition
    }

    public void playVoice5()
    {
        if (!hasPlayed)
        {
            // Assign other game objects
            carAI = GameObject.Find("DrivableSmartCommon-no_driver(Clone)");
            dashWarning = GameObject.Find("Dash_Warning"); 
            reactionTimeTracker = GameObject.Find("ReactionTimeTracker");

            StartCoroutine(Voice5Coroutine());
            hasPlayed = true; // Set to true so it doesn't play again
        }
    }

    IEnumerator Voice5Coroutine()
    {
        audioSource.Play();  // Play the sound once
        yield return new WaitForSeconds(audioSource.clip.length);  // Wait for the duration of the audio clip
    }
}
