using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : Bullet
{
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyRef.transform.position, speed * Time.deltaTime);
    }
}
