using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemic : MonoBehaviour
{
    public float m_vida;

    private Rigidbody2D m_rigidBody2d;

    [SerializeField]
    private GameObject m_player;
    
    [SerializeField]
    private float m_spd;

    [SerializeField]
    private TextMeshProUGUI m_text;

    [SerializeField]
    private GameObject[] m_PowerUps;

    [SerializeField]
    private EnemigosLokos m_Lokos;

    private void Awake()
    {
        m_player = GameObject.Find("Player");
    }

    void Start()
    {

        m_vida = m_Lokos.Vida;
        m_spd = m_Lokos.Vel;
        m_rigidBody2d = GetComponent<Rigidbody2D>();
        m_text = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Vector3 direccion = new Vector3(m_player.transform.position.x - this.transform.position.x, m_player.transform.position.y - this.transform.position.y, 0);
        m_rigidBody2d.velocity = direccion.normalized * m_spd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            m_vida--;
            Destroy(collision.gameObject);
            if (m_vida <= 0f)
            {
                float m_score = m_player.GetComponent<PlayerControl>().m_score += 100;
                m_text.text = m_score.ToString();
                int r = Random.Range(0, 11);
                if (r <= 1)
                {
                    int r2 = Random.Range(0, m_PowerUps.Length);
                    Instantiate(this.m_PowerUps[r2],this.transform.position, new Quaternion(0,0,0,0)) ;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
