using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableEnviorment
{
    public abstract class InteractionBehaviour : MonoBehaviour
    {
        public abstract void StartInteracting();
        public abstract void StopInteracting();
        
    }
}
