using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Rendering;
using DG.Tweening;
public class SanityManager : MonoBehaviour
{

    public float sanity = 100;
    public float threat = 0;

    public Image sanityBar, threatBar;



    public static SanityManager instance;
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



    public void SanityChange(float amount,bool constant=false)
    {
        sanity += amount;
        sanity = Mathf.Clamp(sanity, 0, 100);

        if (sanity <= 0)
        {
            Die();
        }
        if (constant)
        {
            sanityBar.fillAmount = sanity / 100;
            return;
        }
        sanityBar.DOFillAmount( sanity / 100,0.2f);
    }

    public void ThreatChange(float amount,bool constant = false)
    {
        threat += amount;
        threat = Mathf.Clamp(threat, 0, 100);
        if (threat >= 100)
        {
            Die();
        }
        if (constant)
        {
            threatBar.fillAmount = threat / 100;
            return;
        }
        threatBar.DOFillAmount(threat / 100, 0.2f);
    }


    public void Die()
    {

    }

}
