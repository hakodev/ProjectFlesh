using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System.Linq;

public class PlayerInteraction : MonoBehaviour
{
    public Interactable currentlyHovering;
    public Item currentlyHolding;
    public float hoverRadius;
    public LayerMask itemLayer;

    public Transform holdTransform;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ItemCheck();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentlyHovering == null) return;
            if (currentlyHovering.TryGetComponent<Item>(out Item i))
            {
                if (currentlyHolding == null)
                {
                    if (i.itemData.holdable)
                    {
                        i.Hold();
                        HoldItem(i);
                        currentlyHovering.Interact();
                    }
                    else
                    {
                        i.Interact();
                    }
                   

                }
                else if (currentlyHolding != null)
                {
                    currentlyHolding.Interact(i);
                }


            }
            else if (currentlyHovering.TryGetComponent(out Horror h))
            {
                h.Interact();
            }


        }






            if (Input.GetKeyDown(KeyCode.Q))
            {

                if (currentlyHolding != null)
                {
                    currentlyHolding.Drop();
                    Drop(currentlyHolding);
                }
            }


        }
    

    public async void HoldItem(Item item)
    {
       if(item.TryGetComponent(out Rigidbody2D rb))
        {
            rb.isKinematic = true;
        }
        anim.SetBool("isGrabbing", true);
        item.transform.DOMoveInTargetLocalSpace(holdTransform, Vector3.zero, 0.5f);
        item.transform.DORotate(Vector3.zero, 0.5f);
        currentlyHolding = item;
        await Task.Delay(500);
        anim.SetBool("isGrabbing", false);

        if (currentlyHolding == item)
        {
            item.transform.parent = holdTransform;
                
        }




    }

    public void Drop(Item item)
    {
        if (item.TryGetComponent(out Rigidbody2D rb))
        {
            rb.isKinematic = false;
        }
        item.transform.parent = null;
        currentlyHolding = null;

    }

    void ItemCheck()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, hoverRadius, itemLayer);
        List<Interactable> itemList = new List<Interactable>();
        foreach (Collider2D c in hitObjects)
        {
            if (c.TryGetComponent(out Item item))
            {
                if (!item.holding)
                {
                    itemList.Add(item);

                }
            }

            if(c.TryGetComponent(out Horror h))
            {
                if (h.active)
                {
                itemList.Add(h);
                }
            }

        }

       itemList= itemList.OrderBy(x => Mathf.Abs(x.transform.position.x-transform.position.x)).ToList();
        if (itemList.Count > 0)
        {
            if (currentlyHovering != itemList[0])
            {

                currentlyHovering?.HoverEnd();

                currentlyHovering = itemList[0];

                itemList[0].HoverStart();

            }
        }
        else
        {
            if (currentlyHovering == null)
            {
            }
            currentlyHovering?.HoverEnd();

            currentlyHovering = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, hoverRadius);
    }

   
}
