using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLoko : MonoBehaviour
{
    private static GameManagerLoko m_instance;

    public static GameManagerLoko Instance
    {
        get { return m_instance; }
    }
    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void GameOver(string n)
    {
        this.ChangeScene(n);
    }
}
