using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gate : Character
{
    [SerializeField] float damage;
    [SerializeField] Image hpBar;

    private void Update()
    {
        hpBar.fillAmount = Mathf.Max(0, actualHP / 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            TakeDamage(damage);
        }
    }

    private void OnDisable()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
