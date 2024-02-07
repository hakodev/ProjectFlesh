using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : Interactable
{

    public GameObject display;
    public bool active=false;

    [HideInInspector]
    public Room location;

    public float drainRatioMult;
    public float threatOnIgnore;

    public void Activate()
    {

        if (location.roomName == "Bedroom")
        {
            FindObjectOfType<PlayerController>().transform.position = new Vector3(-14.94f, -20.5f, 0f);
        }

        display.SetActive(true);
        active = true;
    }

    public void Deactivate()
    {
        display.SetActive(false);

        active = false;

    }

    public void InspectEnd()
    {

    }


    public void Inspect()
    {
        HorrorSystem.instance.StartHorrorSequence(drainRatioMult*location.roomDrainRatioMult);
    }

    public override void Interact()
    {

        Inspect();  
        base.Interact();
    }
}
