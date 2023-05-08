using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    Spawner sp;

    private void Awake()
    {
        sp = FindObjectOfType<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            TakeDamage(1);
        }
    }

    private void OnDisable()
    {
        sp.AddDeadEnemy(gameObject);
    }
}
