using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace InteractableEnviorment
{
    public class TextFade : InteractionBehaviour
    {
        public float fadeSpeed=1;
        public TextMeshProUGUI textDisplay;
        public bool fadeIn;

        public override void StartInteracting()
        {
            if (fadeIn)
            {
                textDisplay.DOFade(1, 1 / fadeSpeed);

            }
            else
            {
                textDisplay.DOFade(0, 1 / fadeSpeed);

            }
        }



        public override void StopInteracting()
        {
            if (fadeIn)
            {
                textDisplay.DOFade(01, 1 / fadeSpeed);

            }
            else
            {
                textDisplay.DOFade(1, 1 / fadeSpeed);

            }

        }
    }
}
