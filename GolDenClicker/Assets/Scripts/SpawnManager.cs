using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> m_spawnPoints = new();

    [SerializeField]
    private List<GameObject> m_enemyPrefavs = new();

    private int m_enemytype;

    [SerializeField]
    private int m_waveCount;

    [SerializeField]
    private int m_wave;

    [SerializeField]
    private bool m_spawning;

    void Start()
    {
        m_waveCount = 2;
        m_wave = 1;
        m_spawning = false;
    }

    private void Update()
    {
        if(!m_spawning)
        {
            StartCoroutine(SpawnWave(m_waveCount));
        }
    }

    IEnumerator SpawnWave(int wC)
    {
        m_spawning = true;
        yield return new WaitForSeconds(4);
        for(int i = 0; i < wC; i++)
        {
            SpawnEnemy(m_wave);
            yield return new WaitForSeconds(2);
        }
        m_wave += 1;
        m_waveCount += 2;
        m_spawning = false;

        yield break;
    }

    void SpawnEnemy(int wafe)
    {
        int spawnPos = Random.Range(0, 8);
        if (wafe == 1)
        {
            m_enemytype = 0;
        }
        else if (wafe < 4 && wafe > 1) 
        {
            m_enemytype = 1;
        }
        else
        {
            m_enemytype = 2;
        }

        Instantiate(m_enemyPrefavs[m_enemytype], m_spawnPoints[spawnPos].transform.position,new Quaternion(0,0,0,0));
    }
}
