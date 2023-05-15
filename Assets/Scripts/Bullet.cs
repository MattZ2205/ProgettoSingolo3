using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public GameObject enemyRef;
    [SerializeField] float speed;
    public int damage;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyRef.transform.position, speed * Time.deltaTime);
    }
}
