using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GameMAneger : MonoBehaviour
{
    public static GameMAneger instance;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform Spawn;
    [SerializeField]public List<Transform> waypoints = new List<Transform>();
    public int wave = 1;
    private int beginnerwave = 0;
    private float time = 0f;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wavesystem();

    }
    private void wavesystem()
    {
        int point = wave * 20;

        switch (wave)
        {
            case 1:
                {
                    time = 1f * 1;
                    break;
                }
                case 2:
                {
                    time = 0.85f * 1; 
                    break;
                }
            case 3:
                {
                    time = 0.75f * 1;
                    break;
                }
            case 4:
                {
                    time = 0.60f * 1;
                    break;
                }
                case 5:
                {
                    time = 0.5f * 1;
                    break;
                }
                default:
                {
                    time = 0.5f * 1;
                    break;
                }
        }
            
        
        if (wave <= 5) 
        {
            int beginnerwave = 1;
        }
        if (point > 0 && beginnerwave != 1)
        {
            StartCoroutine(SpawnEnemiesWithDelay(point, time));
        }
    }

    private IEnumerator SpawnEnemiesWithDelay(int enemyCount, float spawnDelay)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, Spawn.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
        wave += 1;
        wavesystem();
    }
}
