using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public Image Movement;
    public Image Teleport;
    public Image Interact;
    public Image Highlight;
    public Image WorldShift;
    public Image PeriodiskSystem;

    public bool MovementCheck;
    public bool TeleportCheck;
    public bool InteractCheck;
    public bool HighlightCheck;
    public bool WorldShiftCheck;
    public bool PeriodiskSystemCheck;
    public bool hasMoved;
    public bool tutDone;

    public OVRGrabbable grab;
    public Hide PerSys;
    public DualWorldManager DWM;
    public AtomManager AtMan;
    public LocomotionTeleport LoTp;

    void Start()
    {
        hasMoved = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "interactTut")
        {
            Interact.enabled = true;
        }

        if(other.gameObject.name == "highlightTut")
        {
            Highlight.enabled = true;
        }

        if(other.gameObject.name == "worldShiftTut")
        {
            WorldShift.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "interactTut" && InteractCheck == false)
        {
            Interact.enabled = false;
        }

        if(other.gameObject.name == "highlightTut" && HighlightCheck == false)
        {
            Highlight.enabled = false;
        }

        if(other.gameObject.name == "worldShiftTut" && WorldShiftCheck == false)
        {
            WorldShift.enabled = false;
        }
    }


    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp)
            || OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft)
            || OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight)
            || OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown))
        {
            hasMoved = true;
        }

        if (hasMoved == true)
        {
            Movement.enabled = false;
            MovementCheck = true;
        }

        if (DWM.eagleVisionActivated == true)
        {
            Highlight.enabled = false;
            HighlightCheck = true;
        }

        if(AtMan.atomWorld == false)
        {
            WorldShift.enabled = false;
            WorldShiftCheck = true;
        }

        if(grab.hasGrabbed == true)
        {
            Interact.enabled = false;
            InteractCheck = true;
        }

        if(LoTp.playerTeleport == true)
        {
            Teleport.enabled = false;
            TeleportCheck = true;
        }

        if(PerSys.isOpen == true)
        {
            PeriodiskSystem.enabled = false;
            PeriodiskSystemCheck = true;
        }

        if (MovementCheck == true && TeleportCheck == true && InteractCheck == true && HighlightCheck == true && WorldShiftCheck == true && PeriodiskSystemCheck == true)
            tutDone = true;

        if (tutDone == true)
        {
            Teleport.enabled = false;
            Interact.enabled = false;
            Highlight.enabled = false;
            WorldShift.enabled = false;
            PeriodiskSystem.enabled = false;
        }
    }
}
