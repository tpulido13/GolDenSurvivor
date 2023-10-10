using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtraPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            float l_score = collision.gameObject.GetComponent<PlayerControl>().m_score += 1000;
            GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = l_score.ToString();
            Destroy(this.gameObject);
        }
    }
}