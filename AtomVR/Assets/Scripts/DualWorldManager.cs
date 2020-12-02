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
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            if (eagleVisionActivated == false)
                ActivateVision();
            else
                DeactivateVision();
        }
        //Debug.Log(eagleVisionActivated);
    }

    void ActivateVision()
    {
        Debug.Log(interactables);
        interactables = GameObject.FindGameObjectsWithTag("AtomRepresent");

        foreach (GameObject gameobject in interactables)
        {
            gameobject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        }

        eagleVisionActivated = true;
    }

    void DeactivateVision()
    {
        Debug.Log("OFF");
        interactables = GameObject.FindGameObjectsWithTag("AtomRepresent");

        foreach (GameObject gameobject in interactables)
        {
            gameobject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.grey);
        }

        eagleVisionActivated = false;
    }
}
