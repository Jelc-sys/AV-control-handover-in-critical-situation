using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStop : MonoBehaviour
{
    public GameObject colliderFront;
    public AICar AICarScript;

    // Start is called before the first frame update
    void Start()
    {
        colliderFront = GameObject.Find("ColliderFront");
        //AICar = GameObject.Find("AI Car");
        BoxCollider boxCollider = colliderFront.GetComponent<BoxCollider>();
        //AICar aiCar = AICar.GetComponent<AI Car > ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            AICarScript.enabled = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            AICarScript.enabled = true;
        }
    }
}
