using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : Turret
{
    public float rateo;
    public GameObject bullet;
    [SerializeField] Transform muzzle;

    float timer;

    void Start()
    {
        timer = rateo;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (enemyInTarget.Count > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (timer >= rateo)
        {
            GameObject g = bullet;
            g.GetComponent<Bullet>().enemyRef = enemyInTarget[0];
            Instantiate(g, muzzle.position, Quaternion.LookRotation(enemyInTarget[0].transform.position));
            timer = 0;
        }
    }
}
