using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;

public class Item : Interactable
{

    public SpriteRenderer dot;

    public ItemData itemData;
    [HideInInspector]
    public bool holding = false;
    public UnityEvent<int> OnAction;

    public Item itemProduct;



    public Vector3 startPos;


    private void Start()
    {
        startPos = transform.position;
        dot.gameObject.SetActive(true);
    }

    public override void Interact()
    {
        base.Interact();
    }

    public virtual void Interact(Item item = null)
    {
        bool itemWillDestroyed = false;
        if (item == null)
        {
            //player interaction
        }
        foreach (Interaction interaction in itemData.interactions)
        {
            if (interaction.interactionTarget == item.itemData)
            {
                if (interaction.itemProduct != null)
                {
                    Instantiate(interaction.itemProduct, item.transform.position, Quaternion.identity);
                    itemWillDestroyed = true;
                }


                OnAction?.Invoke(interaction.ActionID);

            }
        }

        if (itemWillDestroyed)
        {
            Destroy(item.gameObject);
            FindObjectOfType<PlayerInteraction>().currentlyHovering = null;

        }
    }

    public void Hold()
    {
        holding = true;
        dot.gameObject.SetActive(false);

    }

    public void Drop()
    {
        holding = false;
        transform.DOMove(startPos, 0.5f);
    }

    public override void HoverStart()
    {
        base.HoverStart();
        dot.gameObject.SetActive(false);
    }

    public override void HoverEnd()
    {
        base.HoverEnd();
        if (!holding)
        {
            dot.gameObject.SetActive(true);
                
        }

    }
}


[ExecuteInEditMode]
[System.Serializable]
public class Interaction
{
    public ItemData interactionTarget;
    public int ActionID;
    public Item itemProduct;
    public float sanityChangeAmount;

}