using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Turret : MonoBehaviour
{
    protected List<GameObject> enemyInTarget = new List<GameObject>();

    private void FixedUpdate()
    {
        if (enemyInTarget.Count > 0)
        {
            if (enemyInTarget[0].activeSelf) transform.LookAt(new Vector3(enemyInTarget[0].transform.position.x, transform.position.y, enemyInTarget[0].transform.position.z));
            else enemyInTarget.RemoveAt(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInTarget.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemyInTarget.RemoveAt(0);
        }
    }
}