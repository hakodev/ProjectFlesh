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
    public TextMeshProUGUI infoDisplay;
    public GameObject light;
    public UnityEvent<int> OnSoundPlayed;

    public virtual void Start()
    {
        infoDisplay.text = itemData.itemInfoString;
    }
    public virtual void Interact(InteractableItem item)
    {
        foreach (Interaction interaction in itemData.interactions)
        {
            if (interaction.interactionTarget == item.itemData)
            {
                if (interaction.interactionType == Interaction.InteractionType.ProduceSound)
                {
                    OnSoundPlayed?.Invoke(interaction.audioClipID);
                }
            }
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
        infoDisplay.gameObject.SetActive(true);
        light.SetActive(true);
    }

    public void HoverEnd()
    {
        infoDisplay.gameObject.SetActive(false);
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

}