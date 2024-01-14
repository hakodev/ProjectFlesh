using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InteractableItemData")]
public class ItemData : ScriptableObject
{
    public List<Interaction> interactions = new List<Interaction>();
    public string itemInfoString;
    public bool holdable;
}
