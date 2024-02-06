using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HorrorSystem : MonoBehaviour
{

    public bool horrorActive = false;
    public static HorrorSystem instance;

    public UnityEvent OnHorrorStart, OnHorrorEnd;

    public Volume insaneVolume;



    public GameObject followingFigure;

    private void Start()
    {
        GameManager.instance.OnDayBegin.AddListener(DayBegin);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(this); };

      
    }


    public void DayBegin(int dayCount)
    {


        List<Room> roomList = RoomManager.instance.roooms;
        RoomManager.instance.roooms[Random.Range(0, roomList.Count)].ActivateRandomHorror();
    }

    public async void StartHorrorSequence(float drainRatio)
    {
        //start drain
        //activate bl
        Blink.instance.Fade(1, 0.1f);
        await Task.Delay(100);
        Blink.instance.Fade(0, 0.1f);


        horrorActive = true;
        OnHorrorStart?.Invoke();
        insaneVolume.gameObject.SetActive(true);
        StartCoroutine(DrainSanity(drainRatio));
        followingFigure.SetActive(true);
        SanityManager.instance.ThreatChange(drainRatio * +30);
    }


    public void EndHorrorSequence()
    {
        horrorActive = false;
        OnHorrorEnd?.Invoke();
        insaneVolume.gameObject.SetActive(false);

    }



    public IEnumerator DrainSanity(float ratio)
    {
        while (true)
        {
            if (!horrorActive) break;
            SanityManager.instance.SanityChange(-ratio, true);

            yield return new WaitForSeconds(1);
        }


    }




}


