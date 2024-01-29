using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Quest")]
public class QuestData : ScriptableObject
{
    public int questID;
    public string questDescription;
    [HideInInspector]
    public bool completed;
    public List<string> questSteps = new List<string>();

   public void Complete()
    {
        completed = true;
    }


}
