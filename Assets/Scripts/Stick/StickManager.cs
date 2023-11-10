using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickManager : MonoBehaviour  
{
    void Start()
    {
        InvokeRepeating(nameof(InstantStick), 5f, 15f);
    }
    void InstantStick()
    {
        GameObject StickObj = StickPool.instace.GetStick();
        if (StickObj!=null)
        {
            StickObj.transform.position = new Vector3(0, 10, 60);
            StickObj.SetActive(true);
        }
    }
}
