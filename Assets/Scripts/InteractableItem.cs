using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InteractableItem : MonoBehaviour
{
    public ItemData itemData;
    [HideInInspector]
    public bool holding = false;
    public GameObject interactionLight;
    public UnityEvent<int> OnAction;

    public InteractableItem itemProduct;
    
    public virtual void Interact(InteractableItem item = null)
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
    public void HoverStart()
    {
        interactionLight.SetActive(true);
    }

    public void HoverEnd()
    {
        interactionLight.SetActive(false);

    }


}


[ExecuteInEditMode]
[System.Serializable]
public class Interaction
{
    public ItemData interactionTarget;
    public int ActionID;
    public InteractableItem itemProduct;
    public float sanityChangeAmount;

}