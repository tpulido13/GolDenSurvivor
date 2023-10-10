using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool Instance { get; private set; }

    public GameObject m_bala;

    public int m_contenido = 50;

    List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
        FillPool();
    }

    void FillPool()
    {
        for(int t = 0; t < m_contenido; t++)
        {
            GameObject go = Instantiate(m_bala);
            go.SetActive(false);

            pool.Add(go);
        }
    }

    public GameObject Get()
    {
        GameObject res;
        if(pool.Count > 0)
        {
            res = pool[pool.Count - 1];
            pool.RemoveAt(pool.Count - 1);
        }
        else
        {
            res = Instantiate(m_bala);
        }
        res.SetActive(true);
        return res;
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        pool.Add(go);
    }
}
