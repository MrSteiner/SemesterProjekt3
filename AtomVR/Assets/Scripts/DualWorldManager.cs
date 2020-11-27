using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWorldManager : MonoBehaviour
{
    private bool eagleVisionActivated;
    private Ray ray;
    private RaycastHit hit;
    private Color originalColor;
    private int layerMask = 1 << 8;

    void Start()
    {
        eagleVisionActivated = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (eagleVisionActivated == false)
                ActivateVision();
            else
                DeactivateVision();
        }
    }

    void ActivateVision()
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Represent"))
            {
                originalColor = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            }
        }
    }

    void DeactivateVision()
    {
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.CompareTag("Represent"))
            {
                originalColor = hit.collider.gameObject.GetComponent<MeshRenderer>().material.color;
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", originalColor);
            }
        }
    }
}
