using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableEnviorment
{
    public class DestroyTarget : InteractionBehaviour
    {
        public GameObject target;
        public float delay=0;
        public override void StartInteracting()
        {
            Destroy(target, delay);
        }

        public override void StopInteracting()
        {
        }
    }
}
