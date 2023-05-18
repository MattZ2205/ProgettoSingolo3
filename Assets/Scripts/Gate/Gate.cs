using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Gate : Character
{
    [SerializeField] float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(damage);
        }
    }

    private void OnDisable()
    {
        //LoseGame
    }
}
