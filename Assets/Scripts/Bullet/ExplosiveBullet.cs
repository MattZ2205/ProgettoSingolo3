using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExplosiveBullet : Bullet
{
    [SerializeField] float range;
    [SerializeField] LayerMask mask;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyRef.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Collider[] hitted = Physics.OverlapSphere(transform.position, range, mask);
            for (int i = 0; i < hitted.Length; i++)
            {
                hitted[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
