using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;
using System.Linq;

public class PlayerInteraction : MonoBehaviour
{
    public InteractableItem currentlyHovering;
    public InteractableItem currentlyHolding;
    public float hoverRadius;
    public LayerMask itemLayer;

    public Transform holdTransform;


    private void Update()
    {
        ItemCheck();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentlyHovering != null && currentlyHolding==null)
            {
                if (currentlyHovering.itemData.holdable)
                {

                    currentlyHovering.Hold();
                    Hold(currentlyHovering);
                }
                else
                {
                    InteractableItem item =Instantiate(currentlyHolding.itemProduct,currentlyHolding.transform.position,Quaternion.identity);
                    item.Hold();
                    Hold(item);
                }
            }
            else if (currentlyHovering!=null && currentlyHolding != null) 
            {
                currentlyHolding.Interact(currentlyHovering);
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

    public async void Hold(InteractableItem item)
    {
       if(item.TryGetComponent(out Rigidbody2D rb))
        {
            rb.isKinematic = true;
        }
        item.transform.DOMoveInTargetLocalSpace(holdTransform, Vector3.zero, 0.5f);
        item.transform.DORotate(Vector3.zero, 0.5f);
        currentlyHolding = item;
        await Task.Delay(500);
        if (rb != null)
        {
            if (rb.isKinematic)
            {
                item.transform.parent = holdTransform;

            }
        }
            

    }

    public void Drop(InteractableItem item)
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
        List<InteractableItem> itemList = new List<InteractableItem>();
        foreach (Collider2D c in hitObjects)
        {
            if (c.TryGetComponent(out InteractableItem item))
            {
                if (!item.holding)
                {
                    itemList.Add(item);

                }
            }
        }

       itemList= itemList.OrderBy(x => Vector2.Distance(x.transform.position,transform.position)).ToList();
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
                Debug.Log("ss");
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
