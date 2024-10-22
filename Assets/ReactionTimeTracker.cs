using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ReactionTimeTracker : MonoBehaviour
{
    public KeyCode reactionKey = KeyCode.LeftArrow; // Key to stop the timer
    public KeyCode reactionKey2 = KeyCode.RightArrow;
    public KeyCode reactionKey3 = KeyCode.DownArrow;
    public KeyCode reactionKey4 = KeyCode.UpArrow;//Second key to stop the timer
    private float startTime; // Time when the visual cue appears
    private bool isTiming = false; // To track if the timer is running
    private string filePath; // Path to save the data
    public bool VisualCueTriggered = false;
    public string reasonForActivation;

    void Start()
    {
        filePath = Application.persistentDataPath + "/reaction_times.txt";
    }

    // Update is called once per frame
    void Update()
    {
        if (isTiming && (Input.GetKeyDown(reactionKey) || Input.GetKeyDown(reactionKey2) || Input.GetKeyDown(reactionKey3) || Input.GetKeyDown(reactionKey4)))
        {
            StopTimer();
        }
    }

    public void StartTimer(String reason)
    {
        VisualCueTriggered = true;
        startTime = Time.time; // Start counting time
        isTiming = true;
        Debug.Log("Timer started");
        reasonForActivation = reason;
    }

    public void StopTimer()
    {
        float reactionTime = Time.time - startTime;
        isTiming = false;
        Debug.Log("Timer stopped. Reaction Time: " + reactionTime + " seconds");

        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("Reaction Time: " + reactionTime + " seconds");
            //writer.WriteLine("Reason for activation: " + reasonForActivation);
        }
        Debug.Log("Reaction time saved to: " + filePath);

        VisualCueTriggered = false;


    }
}
