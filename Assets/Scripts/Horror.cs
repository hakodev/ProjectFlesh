using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horror : MonoBehaviour
{


    public GameObject horrorRedDisplay;
    public GameObject horrorMainDisplay;
    public GameObject horrorLeftOverDisplay;


    public void Activate()
    {
        horrorMainDisplay.SetActive(true);
        horrorRedDisplay.SetActive(false);
    }

    public void HorrorEnd()
    {
        horrorLeftOverDisplay.SetActive(true);
    }
}
