using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemigo", menuName = "Scriptable Objects/Enemigo Generico")]
public class EnemigosLokos : ScriptableObject
{
    [SerializeField]
    private float m_vida;
    
    public float Vida => m_vida;

    [SerializeField]
    private float m_vel;

    public float Vel => m_vel;

}
