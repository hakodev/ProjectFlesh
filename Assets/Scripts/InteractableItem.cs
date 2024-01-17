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
    public GameObject light;
    public UnityEvent<int> OnSoundPlayed;

    public virtual void Start()
    {
        OnSoundPlayed.AddListener(SoundClipManager.instance.OnSoundPlayedByInteraction);
    }
    public virtual void Interact(InteractableItem item=null)
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
                if (interaction.interactionType == Interaction.InteractionType.ProduceSound)
                {
                    OnSoundPlayed?.Invoke(interaction.audioClipID);
                }
                if (interaction.interactionType == Interaction.InteractionType.ProduceItem)
                {
                    Instantiate(interaction.itemProduct,item.transform.position,Quaternion.identity);
                    OnSoundPlayed?.Invoke(interaction.audioClipID);

                    itemWillDestroyed = true;
                }
                Debug.Log(interaction.sanityChangeAmount);

                FindObjectOfType<SanityManager>().SanityChange(interaction.sanityChangeAmount);
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
        light.SetActive(true);
    }

    public void HoverEnd()
    {
        light.SetActive(false);

    }


}


[ExecuteInEditMode]
[System.Serializable]
public class Interaction
{
    public ItemData interactionTarget;
    public enum InteractionType { ProduceSound, ProduceItem };
    public InteractionType interactionType;
    [Header("Use if interaction type is ProduceSound")]
    public int audioClipID;
    [Header("Use if interaction type is ProduceItem")]
    public InteractableItem itemProduct;
    public float sanityChangeAmount;

}