using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPool : MonoBehaviour
{
    public static StickPool instace;
    public List<GameObject> StickList = new List<GameObject>();
    public GameObject Stick;
    public int StickCount;
    private void Awake()
    {
        if (instace == null)
        {
            instace = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < StickCount; i++)
        {
            GameObject StickObj = Instantiate(Stick);
            StickObj.transform.SetParent(transform);
            Stick.SetActive(false);
            StickList.Add(StickObj);
        }
    }
    public GameObject GetStick()
    {
        foreach (var obj in StickList)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
}
