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
    private Image timerSlider;
    [HideInInspector]
    public float sanity;

    [HideInInspector]
    public float timer;
    public float sanityFadeRate=1;
    public float maxSanity = 50;
    public float maxTimer = 20;

    public Volume sanePostProcess, insanePostProcess;
    private void Start()
    {   
        sanity = maxSanity;
    }

    private void Update()
    {
        TimerChange(-Time.deltaTime * sanityFadeRate);
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
        DOVirtual.Float(currentWeight, targetWeight, 0.3f,v=>insanePostProcess.weight=v);
       
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
