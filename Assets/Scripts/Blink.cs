using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Blink : MonoBehaviour
{
    public Image blackScreen;
    public static Blink instance;


    private void Awake()
    {
       if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Fade(float val,float duration)
    {
        blackScreen.DOFade(val, duration);
    }
}
