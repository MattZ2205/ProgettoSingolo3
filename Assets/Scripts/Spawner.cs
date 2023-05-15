using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] pathPoint;
    [SerializeField] float spawnTime;

    List<GameObject> aliveEnemy = new List<GameObject>();
    List<GameObject> deadEnemy = new List<GameObject>();
    float timer;

    private void Awake()
    {
        Enemy.onEnemyDead += AddDeadEnemy;
    }

    private void OnDisable()
    {
        Enemy.onEnemyDead -= AddDeadEnemy;
    }

    private void Start()
    {
        timer = spawnTime;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer = 0;
            if (deadEnemy.Count > 0) RespawnEnemy();
            else SpawnNewEnemy();
        }
    }

    void RespawnEnemy()
    {
        GameObject g = deadEnemy[0];
        g.GetComponent<EnemyMovement>().ind = 0;
        g.transform.position = transform.position;
        g.SetActive(true);
        aliveEnemy.Add(g);
        deadEnemy.RemoveAt(0);
    }

    void SpawnNewEnemy()
    {
        GameObject g = Instantiate(enemy);
        g.transform.position = transform.position;
        EnemyMovement en = g.GetComponent<EnemyMovement>();
        en.points = new Transform[pathPoint.Length];
        for (int i = 0; i < pathPoint.Length; i++)
        {
            en.points[i] = pathPoint[i];
        }
        aliveEnemy.Add(g);
    }

    public void AddDeadEnemy(GameObject enemy)
    {
        aliveEnemy.Remove(enemy);
        deadEnemy.Add(enemy);
    }
}