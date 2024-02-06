using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    //add more rooms as needed



    public List<Room> roooms = new List<Room>();

    public static RoomManager instance;


    private void Start()
    {
        foreach(Room r in roooms)
        {
            r.InitializeHorrors();
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        
    }

}
