using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public GameObject enemyRef;
    [SerializeField] protected float speed;
    public int damage;
}
