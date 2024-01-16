using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShard : InteractableItem
{
    public ItemData catItemData;
    public ParticleSystem bloodParticle;
    public int sound;
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
            Destroy(item.gameObject);
            return;
        }
        foreach (Interaction interaction in itemData.interactions)
        {
            if (interaction.interactionTarget == item.itemData)
            {
                if (interaction.interactionType == Interaction.InteractionType.ProduceSound)
                {
                    OnSoundPlayed?.Invoke(interaction.audioClipID);
                }
                if (interaction.interactionType == Interaction.InteractionType.ProduceItem)
                {
                    Instantiate(interaction.itemProduct, item.transform.position, Quaternion.identity);
                    Destroy(item.gameObject);
                }
                FindObjectOfType<SanityManager>().SanityChange(interaction.sanityChangeAmount);
            }
        }

        Destroy(this.gameObject);
    }
}
