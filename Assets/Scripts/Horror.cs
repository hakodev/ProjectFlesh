using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : Interactable
{

    public bool active=false;


    public Room location;

    public float drainRatioMult;
    public float threatOnInspect;
    public float threatOnIgnore;

    public void Activate()
    {
      
        active = true;
    }

    public void Deactivate()
    {
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
