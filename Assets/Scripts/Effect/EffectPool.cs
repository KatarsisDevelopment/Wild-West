using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPool : MonoBehaviour
{
    public static EffectPool instance;
    public List<GameObject> EffectList = new List<GameObject>();
    public GameObject Effect;
    public int EffectCount = 20;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < EffectCount; i++)
        {
            GameObject EffectObj = Instantiate(Effect);
            EffectObj.transform.SetParent(transform);
            EffectObj.SetActive(false);
            EffectList.Add(EffectObj);
        }
    }
    public GameObject GetEffect()
    {
        foreach (var obj in EffectList)
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
