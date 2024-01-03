using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace InteractableEnviorment
{
    public class SpriteRendererFade : InteractionBehaviour
    {
        public float fadeSpeed;
        public SpriteRenderer spriteRenderer;

        public bool fadeIn;
        public override void StartInteracting()
        {
            if (fadeIn)
            {
                spriteRenderer.DOFade(1, 1 / fadeSpeed);

            }
            else
            {
                spriteRenderer.DOFade(0, 1 / fadeSpeed);

            }
        }

       

        public override void StopInteracting()
        {
            if (fadeIn)
            {
                spriteRenderer.DOFade(0, 1 / fadeSpeed);

            }
            else
            {
                spriteRenderer.DOFade(1, 1 / fadeSpeed);

            }

        }


    }
}
