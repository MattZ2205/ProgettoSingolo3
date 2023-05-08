using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Turret : MonoBehaviour
{
    GameObject enemyLocked;
    bool isLocked = false;

    private void FixedUpdate()
    {
        if (enemyLocked == null)
        {
            isLocked = false;
        }

        if (isLocked)
        {
            transform.LookAt(new Vector3(enemyLocked.transform.position.x, transform.position.y, enemyLocked.transform.position.z));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyLocked = other.gameObject;
            isLocked = true;
        }
    }
}
