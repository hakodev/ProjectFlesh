using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InteractableEnviorment
{
    public abstract class InteractableObject : MonoBehaviour
    {
        public abstract void StartInteracting();
        public abstract void StopInteracting();
        
    }
}
