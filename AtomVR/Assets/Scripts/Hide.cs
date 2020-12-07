using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public Image image;
    public GameObject LeftHand;
    public Canvas canvas;
    public bool isOpen;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        isOpen = false;
    }
    void Update()
    {
        canvas.transform.position = LeftHand.transform.position;
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            if(isOpen == false)
            {
                image.enabled = true;
                isOpen = true;
            }
            else
            {
                image.enabled = false;
                isOpen = false;
            }
        }
    }
}
