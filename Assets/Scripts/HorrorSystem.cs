using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HorrorSystem : MonoBehaviour
{
    public static HorrorSystem instance;

    public UnityEvent horrorStart, horrorEnd;

    public void StartHorrorSequence()
    {
        horrorStart?.Invoke();
    }


    public void EndHorrorSequence()
    {
        horrorEnd?.Invoke();

    }
}
