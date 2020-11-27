using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWorldManager : MonoBehaviour
{
    private GameObject[] interactables;
    private bool eagleVisionActivated;

    void Start()
    {
        eagleVisionActivated = false;
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (eagleVisionActivated == false)
                ActivateVision();
            else
                DeactivateVision();
        }
    }

    void ActivateVision()
    {
        Debug.Log("Works");
        interactables = GameObject.FindGameObjectsWithTag("Represent");

        foreach (GameObject gameobject in interactables)
        {
            gameobject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        }

        eagleVisionActivated = true;
    }

    void DeactivateVision()
    {
        Debug.Log("OFF");
        interactables = GameObject.FindGameObjectsWithTag("Represent");

        foreach (GameObject gameobject in interactables)
        {
            gameobject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        }

        eagleVisionActivated = false;
    }
}
