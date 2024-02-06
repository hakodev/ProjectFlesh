using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Item
{
    public ParticleSystem bloodParticle;
    public ItemData blenderData;
    public override void Interact(Item item)
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
