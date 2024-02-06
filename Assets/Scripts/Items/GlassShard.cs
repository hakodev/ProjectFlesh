using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShard : Item
{
    public ItemData catItemData;
    public ParticleSystem bloodParticle;

    /*
    public override void Interact(InteractableItem item = null)
    {
        if (item == null)
        {
            //player interaction
        }
        if (item.itemData == catItemData)
        {

            bloodParticle.transform.position = item.transform.position;
            bloodParticle.Play();

            FindObjectOfType<PlayerInteraction>().currentlyHovering = null;
            Destroy(item.gameObject);
            return;
        }
        foreach (Interaction interaction in itemData.interactions)
        {
            if (interaction.interactionTarget == item.itemData)
            {
                if (interaction.interactionType == Interaction.InteractionType.ProduceSound)
                {
                    OnSoundPlayed?.Invoke(interaction.ActionID);
                }
                if (interaction.interactionType == Interaction.InteractionType.ProduceItem)
                {
                    Instantiate(interaction.itemProduct, item.transform.position, Quaternion.identity);

                    Destroy(item.gameObject);
                    FindObjectOfType<PlayerInteraction>().currentlyHovering = null;

                }
                Debug.Log(interaction.sanityChangeAmount);
                FindObjectOfType<SanityManager>().SanityChange(interaction.sanityChangeAmount);
            }
        }

        Destroy(this.gameObject);
    }
    */
}
