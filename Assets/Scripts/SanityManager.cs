using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;
public class SanityManager : MonoBehaviour
{
    public UnityEvent OnDeath;
    [SerializeField]
    private Image sanitySlider;

    [HideInInspector]
    public float sanity;

    public float sanityFadeRate=1;
    public float maxSanity = 100;

    public Volume sanePostProcess, insanePostProcess;
    private void Start()
    {
        sanity = maxSanity;
    }

    private void Update()
    {
        SanityChange(-Time.deltaTime * sanityFadeRate);
    }



    public void SanityChange(float amount)
    {
        sanity += amount;
        insanePostProcess.weight = 1 - (sanity / maxSanity);
        UpdateUI();
        if (sanity <= 0)
        {
            Die();
        }
        
    }

    public void UpdateUI()
    {
        sanitySlider.fillAmount = (sanity / maxSanity);
    }

    public void Die()
    {
        OnDeath?.Invoke();
    }


}
