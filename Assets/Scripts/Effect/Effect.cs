using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour  
{
    void Start()
    {
        InvokeRepeating(nameof(Disable), 3f, 3f);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }

}
