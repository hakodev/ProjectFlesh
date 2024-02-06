using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public int dayCount;

    public static GameManager instance;
    public UnityEvent<int> OnDayBegin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        NewDay();
    }
    //we dont refresh the scene instead re initialize every task
     void NewDay()
    {

        dayCount++;
        OnDayBegin?.Invoke(dayCount);

        //re initialize tasks
        QuestSystem.instance.DayBegin();

    }


    public void EndDay()
    {

    }



}
