using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;
using DG.Tweening;
public class SanityManager : MonoBehaviour
{
    public UnityEvent OnDeath;
    [SerializeField]
    private Image sanitySlider;
    [SerializeField]
    private Image timerSlider;


    [HideInInspector]
    public float sanity;

    [HideInInspector]
    public float timer;
    public float timeFadeRate=1;
    public float maxSanity = 50;
    public float maxTimer = 20;

    public Volume sanePostProcess, insanePostProcess;
    private void Start()
    {   
        sanity = maxSanity;
        timer = maxTimer;
    }

    private void Update()
    {
        TimerChange(-Time.deltaTime * timeFadeRate);
    }

    public void TimerChange(float amount)
    {
        timer += amount;
        UpdateUI();
        if (sanity <= 0)
        {
            Die();
        }
    }

    public void SanityChange(float amount)
    {
        sanity += amount;
        float currentWeight = insanePostProcess.weight;
        float targetWeight = 1 - (sanity / maxSanity);
        //insanePostProcess.weight = 1 - (sanity / maxSanity);
        DOVirtual.Float(currentWeight, targetWeight, 1f,v=>insanePostProcess.weight=v);
       
        UpdateUI();
        if (sanity <= 0)
        {
            Die();
        }
        
    }

    public void UpdateUI()
    {
        sanitySlider.fillAmount = (sanity / maxSanity);
        timerSlider.fillAmount = (timer / maxTimer);
    }

    public void Die()
    {
        OnDeath?.Invoke();
    }


}
