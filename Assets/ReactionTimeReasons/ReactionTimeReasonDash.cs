using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ReactionTimeReasonDash : MonoBehaviour
{
    private string filePath; // Path to save the data
    public string reasonForActivation;

    void Start()
    {
        //reasonForActivation = "visual";
        filePath = Application.persistentDataPath + "/reaction_times.txt";
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine();
            writer.WriteLine("Reason for activation: " + reasonForActivation);
        }
        Debug.Log("Reaction time saved to: " + filePath);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Reason(string reason)
    {
        
    }
}
