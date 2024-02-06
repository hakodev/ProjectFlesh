using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class HorrorSystem : MonoBehaviour
{

    public bool horrorActive = false;
    public static HorrorSystem instance;

    public UnityEvent horrorStart, horrorEnd;

    public Volume insaneVolume;


    Coroutine drainRoutine;

    private void Start()
    {
      //  GameManager.instance.OnDayBegin.AddListener(DayBegin);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }


    public void DayBegin(int dayCount)
    {


        List<Room> roomList = RoomManager.instance.roooms;
        RoomManager.instance.roooms[Random.Range(0, roomList.Count)].ActivateRandomHorror();
    }

    public void StartHorrorSequence(float drainRatio)
    {
        //start drain
        //activate 
        horrorActive = true;
        horrorStart?.Invoke();
        insaneVolume.gameObject.SetActive(true);
        drainRoutine = StartCoroutine(DrainSanity(drainRatio));
        SanityManager.instance.ThreatChange(drainRatio * -30);
    }


    public void EndHorrorSequence()
    {
        horrorActive = false;
        horrorEnd?.Invoke();
        insaneVolume.gameObject.SetActive(false);
        StopCoroutine(drainRoutine);

    }



    public IEnumerator DrainSanity(float ratio)
    {
        while (true)
        {
            SanityManager.instance.SanityChange(-ratio, true);

            yield return new WaitForSeconds(1);
        }


    }




}


