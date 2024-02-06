using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class HorrorSystem : MonoBehaviour
{

    public bool horrorActive=false;
    public static HorrorSystem instance;

    public UnityEvent horrorStart, horrorEnd;

    public Volume insaneVolume;


    Coroutine drainRoutine;

    private void Start()
    {
        GameManager.instance.OnDayBegin.AddListener(DayBegin);
    }



    public void DayBegin(int dayCount)
    {
       

        List<Room> roomList = RoomManager.instance.roooms;
        RoomManager.instance.roooms[Random.Range(0, roomList.Count)].ActivateRandomHorror();
    }

    public void StartHorrorSequence()
    {
        //start drain
        //activate 
        horrorActive = true;
        horrorStart?.Invoke();
        insaneVolume.gameObject.SetActive(true);
    }


    public void EndHorrorSequence()
    {
        horrorActive = false;
        horrorEnd?.Invoke();
        insaneVolume.gameObject.SetActive(false);


    }



    public IEnumerator DrainSanity(float ratio)
    {
        yield return null;
    }




}


