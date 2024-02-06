using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room :MonoBehaviour
{

    public string roomName;

    public List<Horror> avaibleHorrors = new List<Horror>();

    public float roomDrainRatioMult;


   public void LeaveRoom()
    {
        foreach(Horror h in avaibleHorrors)
        {
            if (h.active)
            {
                Debug.Log("ignore damage");
                SanityManager.instance.ThreatChange(h.threatOnIgnore);
            }
        }
    }



    public void InitializeHorrors()
    {
        foreach(Horror h in avaibleHorrors)
        {
            h.location = this;
        }
    }

    public void ActivateRandomHorror()
        
    {
        Debug.Log("hello"+this.gameObject.name);
        avaibleHorrors[Random.Range(0, avaibleHorrors.Count)].Activate();

    }
}
