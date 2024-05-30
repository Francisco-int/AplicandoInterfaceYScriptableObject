using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private List<Enemy> enemiesInRange = new List<Enemy>();

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.R))
        {
            InteractuarEnemigosCerca();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            AtacarEnemigosCerca();
        }
    }

    void InteractuarEnemigosCerca()
    {
        Enemy nearestEnemy = DetectarEnemigosCerca();
        if (nearestEnemy != null)
        {
            nearestEnemy.Accion();
        }
    }

    void AtacarEnemigosCerca()
    {
        if (enemiesInRange.Count > 0)
        {
            Enemy enemigoCerca = enemiesInRange[0]; 
            IDaño damageable = enemigoCerca as IDaño;
            if (damageable != null)
            {
                damageable.TakeDamage(2);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && !enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Add(enemy);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemiesInRange.Contains(enemy))
        {
            enemiesInRange.Remove(enemy);
        }
    }

    Enemy DetectarEnemigosCerca()
    {
        Enemy nearest = null;
        float minDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemiesInRange)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearest = enemy;
            }
        }
        return nearest;
    }
}
