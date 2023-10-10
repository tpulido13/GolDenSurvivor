using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset m_inputActions;
    private InputActionAsset m_inputAction;
    private InputAction m_action;

    [SerializeField]
    private List<GameObject> m_enemies = new(); 

    private GameObject m_enemy; 
    private GameObject m_bala;

    [SerializeField]
    private GameManagerLoko m_gm;


    public float m_vida = 3f;

    public float m_score;

    void Awake()
    {
        m_inputAction = Instantiate(m_inputActions);
        m_action = m_inputAction.FindActionMap("Land").FindAction("Mover"); 
        m_action.performed += Movedor;

        m_inputAction.FindActionMap("Land").Enable();
        m_score = 0;

    }
    private void Movedor(InputAction.CallbackContext context)
    {
        //Debug.Log(context);
    }

    private void Start()
    {
        m_gm = GetComponent<GameManagerLoko>();
    }
    void Update()
    {
        Vector2 delta = m_action.ReadValue<Vector2>();
        transform.position += 3f * new Vector3(delta.x, delta.y, 0) * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        if (m_enemies.Count != 0)
        {
            m_enemy = m_enemies[Random.Range(0, m_enemies.Count)];
            if (m_enemy != null)
            {
                Vector2 Direccion = m_enemy.transform.position - this.gameObject.transform.position;
                Transform shotPoint = this.transform;
                m_bala = Pool.Instance.Get();
                m_bala.transform.position = shotPoint.position;
                Rigidbody2D rigbala = m_bala.GetComponent<Rigidbody2D>();
                rigbala.velocity = Direccion.normalized * 6;
            }
            else
            {
                Debug.Log(string.Format("No hay enemigos cerca."));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            this.m_vida-=1f;
            Destroy(collision.gameObject);
            if (m_vida <= 0f)
            {
                m_gm.GameOver("Menu");
                Destroy(this.gameObject);
            }
        }
    }

    public void Entra(GameObject enemic)
    {
        m_enemies.Add(enemic);
    }

    public void Surt(GameObject enemic)
    {
        m_enemies.Remove(enemic);
    }
}
