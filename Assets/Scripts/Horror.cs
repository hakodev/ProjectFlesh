using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : Interactable
{

    public bool active=false;


   

    public float drainRatio;
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
        HorrorSystem.instance.StartHorrorSequence();
    }
}
