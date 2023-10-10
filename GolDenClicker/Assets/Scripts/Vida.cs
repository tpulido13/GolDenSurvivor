using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerControl>().m_vida++;
            if (collision.gameObject.GetComponent<PlayerControl>().m_vida >= 3f)
            {
                collision.gameObject.GetComponent<PlayerControl>().m_vida = 3f;
            }
            Destroy(this.gameObject);
        }
    }
}
