using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
        SceneManager.sceneLoaded += Initialize;
        NewDay();
    }

    public void Initialize(Scene scene, LoadSceneMode mode)
    {
        NewDay();

    }


   

    //we dont refresh the scene instead re initialize every task
    void NewDay()
    {

        dayCount++;
        OnDayBegin?.Invoke(dayCount);
        HorrorSystem.instance.DayBegin(0);
        //re initialize tasks
        QuestSystem.instance.DayBegin();

    }


    public async void EndDay()
    {
        Blink.instance.Fade(1, 0.7f);
        await Task.Delay(1000);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }



}
