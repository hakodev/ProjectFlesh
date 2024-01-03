using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace InteractableEnviorment
{
    public class DistanceTrigger : InteractionTrigger
    {
        [SerializeField]
        private float range=1;

        bool playerInRange;
       


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
                    ActivateTrigger();
                    playerInRange = true;

                }

            }
            else
            {
                if (playerInRange)
                {
                    DeactivateTrigger();

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
