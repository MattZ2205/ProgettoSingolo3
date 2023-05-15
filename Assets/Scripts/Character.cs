using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float maxHP;

    protected float actualHP;

    private void Start()
    {
        actualHP = maxHP;
    }

    protected void TakeDamage(float damage)
    {
        actualHP -= damage;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (actualHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
