using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Threading.Tasks;
namespace InteractableEnviorment
{
    public class PostProcessBlend : InteractionBehaviour
    {
        public Volume blendVolume;
        public float blendTime;

        //add cancelation token

        public override void StartInteracting()
        {
            WeightIncreaseLoop();
        }

        public override void StopInteracting()
        {
            WeightDecreaseLoop();
        }

        public async void WeightIncreaseLoop()
        {
            blendVolume.gameObject.SetActive(true);
            float t = 0;
            blendVolume.priority = 5;

            while (t < 1)
            {
                blendVolume.weight = Mathf.Lerp(0, 1, t);
                t += Time.fixedDeltaTime/blendTime;
                await Task.Delay(20);
                
            }
        }


        public async void WeightDecreaseLoop()
        {
            float t = 1;

            while (t >0)
            {
                blendVolume.weight = Mathf.Lerp(0, 1, t);
                t -= Time.fixedDeltaTime / blendTime;
                await Task.Delay(20);
                

            }

            blendVolume.gameObject.SetActive(false);

        }



    }
}
