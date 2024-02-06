using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject interactText;

    public virtual void Interact()
    {

    }

    public virtual void HoverStart()
    {
        interactText.gameObject.SetActive(true);
    }

    public virtual void HoverEnd()
    {
        interactText.gameObject.SetActive(false);

    }
}
