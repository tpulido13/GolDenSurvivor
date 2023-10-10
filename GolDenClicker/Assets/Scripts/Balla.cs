using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balla : MonoBehaviour
{
    private float ttl = 5f;

    void OnEnable()
    {
        StartCoroutine(ReturnToPoolCoroutine());
    }

    IEnumerator ReturnToPoolCoroutine()
    {
        yield return new WaitForSeconds(ttl);
        Pool.Instance.Return(gameObject);
    }
}
