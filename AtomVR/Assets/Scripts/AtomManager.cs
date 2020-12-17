using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomManager : MonoBehaviour
{
    public List<GameObject> Protons;
    public List<GameObject> Neutrons;
    public List<GameObject> Electrons;
    public Atom atom;
    public GameObject atomRepresent;
    public bool atomWorld;
    public Text atomText;

    /*public float rotationTimer = 0.5f;
    private float rotationCoords;
    private Quaternion targetRotation;*/

    void Update()
    {
        /*if(rotationTimer <= Time.time)
        {
            rotationCoords = Random.Range(0f, 360f);
            targetRotation = Quaternion.Euler(rotationCoords + transform.rotation.x, rotationCoords + transform.rotation.y, rotationCoords + transform.rotation.z);
            rotationTimer = Time.time + 1f;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 3f * Time.deltaTime);*/

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!atomWorld)
                WorldShift(true);
            else
                WorldShift(false);
        }
    }

    void Start()
    {
        atom = Atom.Create(2);
        atomWorld = false;
        AtomUpdate();
    }

    void AtomUpdate()
    {
        atomText = GameObject.Find("atomText").GetComponent<Text>();
        int children = transform.childCount;

        for (int i = 0; i < children; ++i)
        {
            GameObject particle = transform.GetChild(i).gameObject;

            if (particle.GetComponent<Proton>())
            {
                Protons.Add(particle);
            }
            else if (particle.GetComponent<Neutron>())
            {
                Neutrons.Add(particle);
            }
            else if (particle.GetComponent<Electron>())
            {
                Electrons.Add(particle);
            }
            else if (particle.GetComponent<DualWorldManager>())
            {
                atomRepresent = particle;
            }
        }

        atomText.text = atom.atomName;
    }
    void WorldShift(bool worldshift)
    {
        foreach (GameObject electron in Electrons)
        {
            electron.SetActive(worldshift);
        }
        foreach (GameObject neutron in Neutrons)
        {
            neutron.SetActive(worldshift);
        }
        foreach (GameObject proton in Protons)
        {
            proton.SetActive(worldshift);
        }

        atomRepresent.SetActive(!worldshift);

        atomWorld = worldshift;
    }
}