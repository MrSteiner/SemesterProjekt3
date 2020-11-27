using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    public Image image;
    public bool isOpen;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
        isOpen = false;
    }
    void Update()
    {
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
