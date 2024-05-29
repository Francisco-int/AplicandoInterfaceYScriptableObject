using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.R))
        {
            InteractWithNearestEnemy();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AttackNearestEnemy();
        }
    }

    void AttackNearestEnemy()
    {
        Enemy nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            ITakeDamage damageable = nearestEnemy as ITakeDamage;
            if (damageable != null)
            {
                damageable.TakeDamage(10); // Define el daño a aplicar
            }
        }
        
    }

  
        void InteractWithNearestEnemy()
    {
        Enemy nearestEnemy = FindNearestEnemy();
        if (nearestEnemy != null)
        {
            nearestEnemy.Accion();
        }
    }
    Enemy FindNearestEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Enemy nearest = null;
        float minDistance = Mathf.Infinity;
        foreach (Enemy enemy in enemies)
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
