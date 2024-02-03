using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int dayCount;

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

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
    public void NewDay()
    {
        dayCount++;
        //re initialize tasks
        QuestSystem.instance.Initialize();

    }





}
