using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    private List<Proton> Protons;
    private List<Neutron> Neutrons;
    private List<Electron> Electrons;
    
    public float rotationTimer = 0.5f;
    private float rotationCoords;
    private Quaternion targetRotation;

    void Update()
    {
        if(rotationTimer <= Time.time)
        {
            rotationCoords = Random.Range(0f, 360f);
            targetRotation = Quaternion.Euler(rotationCoords + transform.rotation.x, rotationCoords + transform.rotation.y, rotationCoords + transform.rotation.z);
            rotationTimer = Time.time + 1f;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
    }
}
