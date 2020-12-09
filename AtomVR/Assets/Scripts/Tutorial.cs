using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Canvas canvas;
    public Image Movement;
    public Image Teleport;
    public Image Interact;
    public Image Highlight;
    public Image DualWorld;
    public Image PeriodiskSystem;
    public GameObject RightHand;
    public GameObject LeftHand;

    public bool MovementCheck;
    public bool TeleportCheck;
    public bool InteractCheck;
    public bool HighlightCheck;
    public bool DualWorldCheck;
    public bool PeriodiskSystemCheck;
    // Start is called before the first frame update
    void Start()
    {
        Teleport.enabled = false;
        Interact.enabled = false;
        Highlight.enabled = false;
        DualWorld.enabled = false;
        PeriodiskSystem.enabled = false;

        MovementCheck = false;
        TeleportCheck = false;
        InteractCheck = false;
        HighlightCheck = false;
        DualWorldCheck = false;
        PeriodiskSystemCheck = false;

        Movement.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.enabled == true)
            canvas.transform.position = LeftHand.transform.position;

        if (Movement.enabled == true && OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp))
        {
            Movement.enabled = false;
            MovementCheck = true;
        }

        if (MovementCheck == true)
        {
            canvas.transform.position = RightHand.transform.position;
            Teleport.enabled = true;
            MovementCheck = false;
        }

        if (Teleport.enabled == true && OVRInput.GetUp(OVRInput.Button.Two) && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            Teleport.enabled = false;
            TeleportCheck = true;
        }

        if (TeleportCheck == true)
        {
            Interact.enabled = true;
            TeleportCheck = false;
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            Interact.enabled = false;
            InteractCheck = true;
        }

        if (InteractCheck == true)
        {
            canvas.transform.position = LeftHand.transform.position;
            DualWorld.enabled = true;
            InteractCheck = false;
        }

        if (DualWorld.enabled == true && OVRInput.GetUp(OVRInput.Button.One))
        {
            DualWorld.enabled = false;
            DualWorldCheck = true;
        }

        if (DualWorldCheck == true)
        {
            canvas.transform.position = RightHand.transform.position;
            Highlight.enabled = true;
            DualWorldCheck = false;
        }

        if (Highlight.enabled == true && OVRInput.GetUp(OVRInput.Button.Three))
        {
            Highlight.enabled = false;
            HighlightCheck = true;
        }

        if (HighlightCheck == true)
        {
            canvas.transform.position = LeftHand.transform.position;
            PeriodiskSystem.enabled = true;
            HighlightCheck = false;
        }

        if (PeriodiskSystem.enabled == true && OVRInput.GetUp(OVRInput.Button.Four))
        {
            PeriodiskSystem.enabled = false;
            MovementCheck = false;
            TeleportCheck = false;
            InteractCheck = false;
            HighlightCheck = false;
            DualWorldCheck = false;
            PeriodiskSystemCheck = true;
        }

        if (PeriodiskSystemCheck == true)
        {
            Teleport.enabled = false;
            Interact.enabled = false;
            Highlight.enabled = false;
            DualWorld.enabled = false;
            PeriodiskSystem.enabled = false;
        }
    }
}
