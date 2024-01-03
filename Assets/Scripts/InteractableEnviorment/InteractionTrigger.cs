using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace InteractableEnviorment
{
    public abstract class InteractionTrigger : MonoBehaviour
    {
        public List<InteractionBehaviour> triggerActivateConnections = new List<InteractionBehaviour>();
        public List<InteractionBehaviour> triggerDeactivateConenctions = new List<InteractionBehaviour>();

    [SerializeField]
        private ExtraConnections extraConnections;

        [System.Serializable]
        public class ExtraConnections
        {
            [Header("Connect to desired interaction")]
            public UnityEvent OnTriggerActivate, OnTriggerDeactivate;
        }

      
        public virtual void ActivateTrigger()
        {
            foreach (InteractionBehaviour i in triggerActivateConnections)
            {

                i.StartInteracting();
             }
            extraConnections.OnTriggerActivate?.Invoke();

        }

        public virtual void DeactivateTrigger()
        {
            foreach (InteractionBehaviour i in triggerActivateConnections)
            {

                i.StopInteracting();
            }
            extraConnections.OnTriggerDeactivate?.Invoke();
        }
    }
}
