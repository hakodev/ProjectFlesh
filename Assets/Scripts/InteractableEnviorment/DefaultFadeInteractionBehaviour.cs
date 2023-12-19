using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
namespace InteractableEnviorment
{
    public class DefaultFadeInteractionBehaviour : InteractableObject
    {
        public float fadeSpeed;
        SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color =new Color(1, 1, 1, 0);
        }
        public override void StartInteracting()
        {
        //    spriteRenderer.DOFade(1, 1 / fadeSpeed);
        }

       

        public override void StopInteracting()
        {
          //  spriteRenderer.DOFade(0, 1 / fadeSpeed);

        }


    }
}
