using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;
using System.Threading.Tasks;

public class Item : Interactable
{

    [HideInInspector]
    public SpriteRenderer itemSprite;
    public SpriteRenderer dot;

    public ItemData itemData;
    [HideInInspector]
    public bool holding = false;
    [HideInInspector]
    public static UnityEvent<int> OnAction;

    public bool isUsed = false;

    public Sprite animSprite;
    public Transform animPos;

    [HideInInspector]
    public Vector3 startPos;

    public int neededID;

    private void Start()
    {
        if (TryGetComponent(out SpriteRenderer sr))
        {
            itemSprite = sr;
        }
        startPos = transform.position;
        dot.gameObject.SetActive(true);
    }

    public override void Interact()
    {
        base.Interact();
    }

    public async virtual void Interact(Item item = null)
    {
        bool itemWillDestroyed = false;


        if (item == null)
        {
            //player interaction
            if (!itemData.holdable)
            {
                if (animSprite != null && neededID==0)
                {

                    isUsed = true;
                    PlayerController pc = FindObjectOfType<PlayerController>();
                    pc.gameObject.transform.position = animPos.position;
                    Sprite s = pc.spriteRenderer.sprite;
                    pc.transform.localEulerAngles = Vector3.zero;
                    pc.GetComponent<Animator>().enabled = false;
                    pc.spriteRenderer.sprite = animSprite;
                    pc.restrictMovement = true;
                    pc.rb2d.gravityScale = 0;
                    Vector3 pcSize = pc.transform.localScale;
                    pc.transform.localScale = Vector3.one;
                    pc.GetComponent<Collider2D>().enabled = false;
                    await Task.Delay(2500);

                    isUsed = false;
                    pc.transform.localScale = pcSize;
                    pc.rb2d.gravityScale = 1;
                    pc.GetComponent<Collider2D>().enabled = true;

                    pc.GetComponent<Animator>().enabled = true;

                    pc.restrictMovement = false;
                    pc.spriteRenderer.sprite = s;
                }

                QuestSystem.instance.CheckQuestAction(itemData.optionalActionID);

            }

        }
        else
        {
            foreach (Interaction interaction in itemData.interactions)
            {
                if (interaction.interactionTarget == item.itemData)
                {
                    if (interaction.itemProduct != null)
                    {
                        Instantiate(interaction.itemProduct, item.transform.position, Quaternion.identity);
                        itemWillDestroyed = true;
                    }
                    QuestSystem.instance.CheckQuestAction(interaction.ActionID);
                    if (interaction.ActionID == 3)
                    {
                        itemWillDestroyed = true;

                    }
                    Debug.Log("itemDestroyed?");

                    Debug.Log(interaction.ActionID + " " + neededID);
                    if (item.animSprite != null && interaction.ActionID == item.neededID)
                    {


                        isUsed = true;
                        PlayerController pc = FindObjectOfType<PlayerController>();
                        pc.gameObject.transform.position = item.animPos.position;
                        Sprite s = pc.spriteRenderer.sprite;
                        pc.transform.localEulerAngles = Vector3.zero;
                        pc.GetComponent<Animator>().enabled = false;
                        pc.spriteRenderer.sprite = item.animSprite;
                        pc.restrictMovement = true;
                        pc.rb2d.gravityScale = 0;
                        Vector3 pcSize = pc.transform.localScale;
                        pc.transform.localScale = Vector3.one;
                        pc.GetComponent<Collider2D>().enabled = false;
                        itemSprite.enabled = false;
                        await Task.Delay(2500);
                        itemSprite.enabled = true;
                        isUsed = false;
                        pc.transform.localScale = pcSize;
                        pc.rb2d.gravityScale = 1;
                        pc.GetComponent<Collider2D>().enabled = true;

                        pc.GetComponent<Animator>().enabled = true;

                        pc.restrictMovement = false;
                        pc.spriteRenderer.sprite = s;
                    }

                }
            }

            if (itemWillDestroyed)
            {
                FindObjectOfType<PlayerInteraction>().currentlyHovering = null;
                Destroy(this.gameObject);

            }
        }


    }

    public void Hold()
    {
        holding = true;
        if (itemSprite != null)
        {
            itemSprite.sortingOrder = 51;

        }
        dot.gameObject.SetActive(false);

    }

    public void Drop()
    {
        holding = false;
        if (itemSprite != null)
        {
            itemSprite.sortingOrder = 2;
        }
        transform.parent = null;
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

}