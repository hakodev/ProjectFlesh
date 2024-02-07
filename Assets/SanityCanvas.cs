using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanityCanvas : MonoBehaviour
{
    public static SanityCanvas instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
