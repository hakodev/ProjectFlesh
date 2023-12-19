using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace InteractableEnviorment
{
    public class DistanceTrigger : InteractableTrigger
    {
        [SerializeField]
        private float range;

        bool playerInRange;
        [Header("Connect to desired interactable object")]
        public UnityEvent OnEnterRange, OnExitRange;


        PlayerController player;

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
        }
        private void Update()
        {
            LogicUpdate();
        }

        private void LogicUpdate()
        {
            if (Mathf.Abs(player.transform.position.x-transform.position.x)<=range){
                if (!playerInRange)
                {
                    OnEnterRange?.Invoke();
                    playerInRange = true;

                }

            }
            else
            {
                if (playerInRange)
                {
                    OnExitRange?.Invoke(); 

                    playerInRange = false;

                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, range);
        }
    }
}
