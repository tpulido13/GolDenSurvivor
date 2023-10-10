using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observador : MonoBehaviour
{
    [SerializeField]
    private PlayerControl m_Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            m_Player.Entra(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_Player.Surt(collision.gameObject);
    }
}

