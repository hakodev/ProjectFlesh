using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InteractableEnviorment
{
    public class KeyPressTrigger : InteractionTrigger
    {

        [SerializeField]
        private float interactableRange=1;
        public GameObject interactableSign;

        PlayerController player;
        bool activated = false;
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
            if (Mathf.Abs(player.transform.position.x - transform.position.x) <= interactableRange)
            {
                interactableSign.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                }


            }
            else
            {
                interactableSign.SetActive(false);      

            }
        }

        public void Interact()
        {
            if (activated)
            {
                DeactivateTrigger();
                activated = false;
                return;
            }
            else if (!activated)
            {
                ActivateTrigger();
                activated = true;

            }
           
        }


    }
}
