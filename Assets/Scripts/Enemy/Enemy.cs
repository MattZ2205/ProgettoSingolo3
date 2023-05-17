using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    Spawner sp;

    private void Awake()
    {
        sp = FindObjectOfType<Spawner>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Barrier"))
        {
            TakeDamage(maxHP);
        }

        if (collision.transform.CompareTag("Bullet"))
        {
            TakeDamage(collision.transform.GetComponent<Bullet>().damage);
            Destroy(collision.gameObject);
        }
    }

    private void OnDisable()
    {
        sp.AddDeadEnemy(gameObject);
    }

    private void OnEnable()
    {
        actualHP = maxHP;
    }
}
