using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace InteractableEnviorment
{
    public class InsaneEffect : MonoBehaviour
    {

        float t;
        [SerializeField]
        float switchSpeed;

        bool goingUp=true;

        Volume postProcessingEffect;
        VolumeProfile volumeProfile;

        private void Start()
        {
            postProcessingEffect = GetComponent<Volume>();
            volumeProfile = postProcessingEffect.profile;

        }
        void Update()
        {
            if (goingUp)
            {
                t += Time.deltaTime * switchSpeed;
                if (t >= 1)
                {
                    goingUp = false;
                }
            }

            else if(!goingUp)
            {
                t -= Time.deltaTime * switchSpeed;
                if (t <= 0)
                {
                    goingUp = true;
                }
            }
           if (volumeProfile.TryGet(out ChromaticAberration chromaticAberration ))
            {
                chromaticAberration.intensity.value = t;
            }

           if(volumeProfile.TryGet(out LensDistortion lensDistortion))
            {
                lensDistortion.intensity.value = t * -0.5f;
            }

           
        }
    }
}
