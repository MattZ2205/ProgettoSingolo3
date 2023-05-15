using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    Spawner sp;
    public delegate void EnemyDeath(GameObject enemy);
    public static EnemyDeath onEnemyDead;
    bool isCancello = false;

    private void Awake()
    {
        sp = FindObjectOfType<Spawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Barrier"))
        {
            isCancello = true;
            gameObject.SetActive(false);
            sp.AddDeadEnemy(gameObject);
        }

        if (collision.transform.CompareTag("Bullet"))
        {
            TakeDamage(collision.transform.GetComponent<Bullet>().damage);
            Destroy(collision.gameObject);
        }
    }

    private void OnDisable()
    {
        if (!isCancello) onEnemyDead?.Invoke(gameObject);
    }

    private void OnEnable()
    {
        actualHP = maxHP;
        isCancello = false;
    }
}
