using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : InteractableItem
{
    public ParticleSystem bloodParticle;
    public ItemData blenderData;
    public override void Interact(InteractableItem item)
    {
        base.Interact(item);
        if (item.itemData == blenderData)
        {
            bloodParticle.Play();
            bloodParticle.transform.parent = null;
            Destroy(this.gameObject);
        }
    }
}
