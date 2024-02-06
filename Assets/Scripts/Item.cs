using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Item : Interactable
{

    public ItemData itemData;
    [HideInInspector]
    public bool holding = false;
    public GameObject interactionLight;
    public UnityEvent<int> OnAction;

    public Item itemProduct;

    public SpriteRenderer dot;


    private void Start()
    {
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
    }

    public void Drop()
    {
        holding = false;

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