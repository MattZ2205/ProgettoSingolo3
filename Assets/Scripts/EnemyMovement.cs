using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector] public Transform[] points;
    [HideInInspector] public int ind = 0;

    [SerializeField] float speed;

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, points[ind].position) >= 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[ind].position, speed * Time.deltaTime);
        }
        else ind++;
    }
}
